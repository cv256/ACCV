''' <summary>
''' Isto retorna Diciotnaries, que sao case-sensitive. Por isso todas as keys sao convertidas para MAIUSCULAS !!!!
''' </summary>
Public Class INIFile

    ' member variables
    Private m_Filename As String
    Private m_Sections As New Dictionary(Of String, Section)
    Private m_SectionChars As String = "[]"
    Private m_RemarkChars As String = ";" & vbTab
    Private m_ParsingErrors As Integer
    Public Encoding As System.Text.Encoding = System.Text.Encoding.Unicode

    ' The Sections collection, that contains all the individual sections of the INI file.
    ReadOnly Property Sections() As Dictionary(Of String, Section)
        Get
            Sections = m_Sections
        End Get
    End Property

    ' The path and name of the INI file
    Property FileName() As String
        Get
            Return m_Filename
        End Get
        Set(ByVal newValue As String)
            m_Filename = newValue
        End Set
    End Property

    ' The textual contents of the INI file.
    Property Text() As String
        Get
            Text = TextFromIniData()
        End Get
        '-----
        Set(ByVal newValue As String)
            IniDataFromText(newValue.Replace(vbLf, vbCr))
        End Set
    End Property

    ' Load the INI file from disk.
    ' If FileName is omitted, it uses the property
    ' with the same name.
    Public Sub Load(Optional ByRef FileName As String = "")
        'Dim fnum As Integer
        'Dim isOpen As Boolean
        Dim tmpText As String = ""

        ' provide missing arguments
        If FileName = "" Then FileName = m_Filename

        ' read the file in one single operation
        'On Error GoTo ErrorHandler
        If Not System.IO.File.Exists(FileName) Then
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(FileName))
            Using f As System.IO.FileStream = System.IO.File.Create(FileName)
                f.Close()
            End Using
        End If
        tmpText = System.IO.File.ReadAllText(FileName, encoding:=Encoding)
        m_Filename = FileName
        ' parse the INI file and exit
        Text = tmpText

        '    fnum = FreeFile
        '    FileOpen(fnum, FileName, OpenMode.Input)
        'isOpen = True
        'tmpText = Input$(LOF(fnum), fnum)
        '    FileClose(fnum)
        '    On Error GoTo 0

        ' if no error, assign the FileName property
        '        m_Filename = FileName

        '        ' parse the INI file and exit
        '        Text = tmpText
        '        Exit Sub

        'ErrorHandler:
        '        ' always close the file if necessary
        '        If isOpen Then FileClose(fnum)

        '        If Err.Number > 0 Then
        '            'Err.Raise Err.Number, TypeName(Me),              "Unable to load file " & FileName & ": " & Err.Description
        '        End If

    End Sub

    ' Save the INI file to disk
    ' If FileName is omitted, it uses the property
    ' with the same name.
    Sub Save(Optional ByRef FileName As String = "")
        'Dim fnum As Integer
        'Dim isOpen As Boolean

        ' provide missing arguments
        If FileName = "" Then FileName = m_Filename
        System.IO.File.WriteAllText(FileName, Text, Encoding)
        m_Filename = FileName

        ' write the file in one single operation
        'On Error GoTo ErrorHandler
        'fnum = FreeFile()
        'FileOpen(fnum, FileName, OpenMode.Output)
        'isOpen = True
        'Print(fnum, Text)
        'FileClose(fnum)
        'On Error GoTo 0

        ' if no error, assign the FileName property
        '        m_Filename = FileName

        '        Exit Sub

        'ErrorHandler:
        '        ' always close the file if necessary
        '        'If isOpen Then FileClose(fnum)

        '        If Err.Number > 0 Then
        '            Err.Raise(Err.Number, TypeName(Me), "Unable to save file " & FileName & "(" & Err.Description & ")")
        '        End If
    End Sub

    ' The characters that enclose a section name. Defaul is "[]".
    Property SectionChars() As String
        Get
            SectionChars = m_SectionChars
        End Get
        '-----
        Set(ByVal newValue As String)
            m_SectionChars = newValue
        End Set
    End Property

    ' All the characters that can mark the beginning of a remark
    ' (must be the first char in a line).
    Property RemarkChars() As String
        Get
            RemarkChars = m_RemarkChars
        End Get
        '-----
        Set(ByVal newValue As String)
            m_RemarkChars = newValue
        End Set
    End Property

    ' Number of errors found when parsing the file
    ReadOnly Property ParsingErrors() As Integer
        Get
            ParsingErrors = m_ParsingErrors
        End Get
    End Property

    Public Function Section(pSection As String) As Section
        If Not Me.Sections.ContainsKey(pSection) Then
            Dim s As New Section With {.Name = pSection}
            Me.Sections.Add(s.Name, s)
        End If
        Return Me.Sections(pSection)
    End Function

    Public Property Value(pSection As String, pKey As String) As String
        Get
            If Not Sections.ContainsKey(pSection) Then Return ""
            If Not Sections(pSection).Keys.ContainsKey(pKey) Then Return ""
            If Sections(pSection).Keys(pKey).Value Is Nothing Then Return ""
            Return Sections(pSection).Keys(pKey).Value
        End Get
        Set(value As String)
            With Section(pSection)
                If Not .Keys.ContainsKey(pKey) Then
                    .Keys.Add(pKey, New Key With {.Name = pKey, .Value = value})
                Else
                    .Keys(pKey).Value = value
                End If
            End With
        End Set
    End Property


    '-------------------------------------------------
    ' Private support procedures
    '-------------------------------------------------

    ' create the dependent objects from text
    Private Sub IniDataFromText(ByVal Text As String)
        Dim lines() As String
        Dim index As Integer, i As Integer
        Dim thisLine As String = ""
        Dim thisSection As Section = Nothing
        Dim thisKey As Key
        Dim thisRemark As String = ""

        ' this protects against sections with same name
        On Error GoTo ParsingError
        m_ParsingErrors = 0

        ' reset all the dependent objects
        m_Sections = New Dictionary(Of String, Section)

        ' get individual lines of text
        lines = Split(Text, vbCr)

        For index = 0 To UBound(lines)
            thisLine = lines(index).Trim

            If thisLine.Length = 0 Then
                ' ignore empty lines
            ElseIf thisLine.Length > 2 AndAlso Strings.Left(thisLine, 1) = Strings.Left(m_SectionChars, 1) AndAlso InStr(thisLine, Strings.Right(m_SectionChars, 1)) > 0 Then
                ' we've found a new section

                ' this method is necessary to account for remarks following the closing "]"
                i = InStr(thisLine, Strings.Right(m_SectionChars, 1))
                thisSection = New Section
                thisSection.Name = Mid(thisLine, 2, i - 2).ToUpper
                thisSection.Remark = thisRemark

                ' in case there is a remark on the same line (but not above)
                If i < Len(thisLine) AndAlso Len(thisRemark) = 0 Then
                    thisLine = LTrim(Mid(thisLine, i + 1))
                    If InStr(m_RemarkChars, Strings.Left(thisLine, 1), CompareMethod.Text) > 0 Then
                        thisSection.Remark = thisLine
                        thisSection.RemarkOnSameLine = True
                    End If
                End If

                ' add to the collection
                m_Sections.Add(thisSection.Name, thisSection)
                ' reset the current remark
                thisRemark = ""

            ElseIf InStr(m_RemarkChars, Strings.Left(thisLine, 1), CompareMethod.Text) > 0 Then
                ' this is a remark
                thisRemark &= thisLine & vbCr
            Else
                ' this must be a key
                ' create a nameless Section, if necessary
                If m_Sections.Count = 0 Then
                    thisSection = New Section
                    m_Sections.Add(thisSection.Name, thisSection)
                End If
                ' create a new key
                thisKey = New Key
                i = InStr(thisLine, "=")
                If i > 0 Then
                    ' a key with a value
                    thisKey.Name = RTrim(Strings.Left(thisLine, i - 1)).ToUpper
                    thisKey.Value = LTrim(Mid(thisLine, i + 1))
                    ' strip out comments:
                    i = 0
                    For Each c As Char In thisKey.Value
                        If InStr(m_RemarkChars, c, CompareMethod.Text) > 0 Then Exit For
                        i += 1
                    Next
                    If i < thisKey.Value.Length Then
                        thisKey.Value = thisKey.Value.Substring(0, i)
                        thisKey.Remark = thisKey.Value.Substring(i)
                        'thisKey.RemarkOnSameLine = True
                    End If
                Else
                    ' a key without a value
                    thisKey.Name = thisLine.ToUpper
                End If
                thisKey.Remark &= thisRemark
                thisRemark = ""
                ' add to the current section
                thisSection.Keys.Add(thisKey.Name, thisKey)
            End If
        Next
        Return

ParsingError:
        ' increment the error count
        m_ParsingErrors += 1
        Resume Next
    End Sub

    ' create text from dependent objects
    Private Function TextFromIniData() As String
        Dim Text As String = ""

        ' let each section do the hard work
        For Each a As Section In Sections.Values
            Text &= a.GetText(True, True).Replace(vbCr, vbCrLf) & vbCrLf
        Next
        Return Text
    End Function

End Class



Public Class Section

    ' member variables
    Private m_Keys As New Dictionary(Of String, Key)
    Private m_Name As String
    Private m_Remark As String
    Private m_SectionChars As String = "[]"
    Private m_RemarkChars As String = ";"
    Private m_RemarkOnSameLine As Boolean

    ' The name of this section (without surrounding brackets).
    Property Name() As String
        Get
            Name = m_Name
        End Get
        '-----
        Set(ByVal newValue As String)
            m_Name = newValue
        End Set
    End Property

    ' The Keys collection
    ReadOnly Property Keys() As Dictionary(Of String, Key)
        Get
            Keys = m_Keys
        End Get
    End Property


    ' The comment associated to this section.
    ' This is the text that precedes this section in the INI file.
    Property Remark() As String
        Get
            Remark = m_Remark
        End Get
        '-----
        Set(ByVal newValue As String)
            ' ensure that each line of the remark start with the right character
            Dim lines() As String, i As Integer
            lines = Split(newValue, vbCr)
            For i = LBound(lines) To UBound(lines)
                If InStr(m_RemarkChars, Strings.Left(lines(i), 1)) = 0 Then
                    lines(i) = Strings.Left(m_RemarkChars, 1) & lines(i)
                End If
            Next
            newValue = Join(lines, vbCr)

            m_Remark = newValue
        End Set
    End Property

    ' True if the remark follows the section
    ' name on the same line. (Friend)
    Property RemarkOnSameLine() As Boolean
        Get
            RemarkOnSameLine = m_RemarkOnSameLine
        End Get
        '-----
        Set(ByVal newValue As Boolean)
            m_RemarkOnSameLine = newValue
        End Set
    End Property

    ' The complete text of this section
    Function GetText(Optional ByVal IncludeKeys As Boolean = False, Optional ByVal IncludeRemarks As Boolean = False) As String
        GetText = ""

        GetText &= Strings.Left(m_SectionChars, 1) & m_Name & Strings.Right(m_SectionChars, 1)

        If Len(m_Remark) = 0 OrElse IncludeRemarks = False Then
            ' ignore remarks or no remarks
        ElseIf m_RemarkOnSameLine Then
            GetText &= " " & m_Remark
        Else
            ' ensure that there is a CR-LF after the remark
            GetText = m_Remark & CStr(IIf(Strings.Right(m_Remark, 2) <> vbCr, vbCr, "")) & GetText
        End If
        ' add a trailing CR-LF
        GetText &= vbCr

        ' add keys, if so requested
        If IncludeKeys Then
            For Each a As Key In Keys.Values
                GetText &= a.GetText(IncludeRemarks)
            Next
        End If
    End Function

    '' Load the section's keys with items from an array of any type
    '' PREFIX is the string used to create items' names (e.g. "item1", "item2", ecc.)

    'Sub LoadFromArray(ByVal arr() As String, Optional ByRef Prefix As String = "", Optional ByVal IgnoreEmptyItems As Boolean = False)
    '    Dim index As Integer

    '    ' start with a null collection
    '    m_Keys = New Dictionary(Of String, Key)
    '    ' provide a reasonable default value for 'prefix'
    '    If Prefix = "" Then Prefix = "Item"

    '    ' scan the array
    '    For index = LBound(arr) To UBound(arr)
    '        If Len(arr(index)) > 0 OrElse IgnoreEmptyItems = False Then
    '            ' add a new key to the collection
    '            Dim a As New Key
    '            a.Name = Prefix & index.ToString()
    '            a.Value = arr(index)
    '            m_Keys.Add(a.Name, a)
    '        End If
    '    Next

    'End Sub

    '' load the contents of the section into an array of any type
    '' (the section can contain other information
    'Sub SaveToArray(ByVal arr As String(), Optional ByRef Prefix As String = "")
    '    Dim index As Integer

    '    ' provide a reasonable default value for 'prefix'
    '    If Prefix = "" Then Prefix = "Item"

    '    On Error Resume Next

    '    ' for each element in the array, look for the
    '    ' corresponding item in the Keys collection
    '    For index = LBound(arr) To UBound(arr)
    '        ' this works with string and numeric arrays
    '        arr(index) = Nothing
    '        ' assign from the collection, if there is a corresponding item
    '        arr(index) = Keys(Prefix & index.ToString).Value.ToString
    '    Next
    'End Sub

    ' Load the section's keys from properties of an object

    'Sub LoadFromObject(ByVal obj As Object, ByVal properties As String())
    '    Dim index As Integer

    '    On Error Resume Next

    '    ' for each property name
    '    For index = LBound(properties) To UBound(properties)
    '        ' retrieve the property value and create the Key in one operation
    '        ' so that if it fails no key is added
    '        Dim a As New Key
    '        a.Name = properties(index)
    '        a.Value = CallByName(obj, properties(index), CallType.Get)
    '        m_Keys.Add(a.Name, a)
    '    Next

    'End Sub

    '' load the contents of the section into an array of any type
    '' (the section can contain other information)

    'Sub SaveToObject(ByVal obj As Object)
    '    On Error Resume Next

    '    For Each a As Key In Keys.Values
    '        ' assign the object's property
    '        CallByName(obj, a.Name, CallType.Set, a.Value)
    '    Next

    'End Sub

End Class



Public Class Key

    ' member variables
    Private m_Name As String
    Private m_Value As String
    Private m_Remark As String
    Private m_RemarkChars As String

    Private Sub Class_Initialize_Renamed()
        m_RemarkChars = ";"
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    ' The name of this key (can't be a null string)
    Public Property Name() As String
        Get
            Name = m_Name
        End Get
        '-----
        Set(ByVal newValue As String)
            If Len(newValue) = 0 Then
                Err.Raise(1001, TypeName(Me), "Invalid Key name")
            End If
            m_Name = newValue
        End Set
    End Property

    ' The value of this key
    Public Property Value() As String
        Get
            Value = m_Value
        End Get
        '-----
        Set(ByVal newValue As String)
            m_Value = newValue
        End Set
    End Property

    ' The comment associated to this key.
    ' This is the text that precedes this key in the INI file.
    Public Property Remark() As String
        Get
            Remark = m_Remark
        End Get
        '-----
        Set(ByVal newValue As String)
            ' ensure that each line of the remark start with the right character
            Dim lines() As String, i As Integer
            lines = Split(newValue, vbCr)
            For i = LBound(lines) To UBound(lines)
                If InStr(m_RemarkChars, Strings.Left(lines(i), 1)) = 0 Then
                    lines(i) = Strings.Left(m_RemarkChars, 1) & lines(i)
                End If
            Next
            newValue = Join(lines, vbCr)

            m_Remark = newValue
        End Set
    End Property

    ' The complete text of this key, including a trailing CR-LF
    Public Function GetText(Optional ByVal IncludeRemark As Boolean = False) As String
        Dim Text As String = m_Name
        If Not String.IsNullOrEmpty(m_Value) Then Text &= "=" & m_Value.ToString
        If IncludeRemark Then Text = m_Remark & Text
        Text &= vbCr
        Return Text
    End Function

End Class


