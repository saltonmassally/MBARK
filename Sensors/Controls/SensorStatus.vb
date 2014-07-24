'
'  Multimodal Biometric Applicaiton Resource Kit (MBARK)
'
'  File author(s):
'       Ross J. Micheals (rossm@nist.gov)
'       Kayee Kwong (kayee@nist.gov)
'
' •—————————————————————————————————————————————————————————————————————————————————————————————————————•
' | LICENSE & DISCLAIMER                                                                                |
' |                                                                                                     |
' | This software was developed at the National Institute of Standards and Technology (NIST) by         |
' | employees of the Federal Government in the course of their official duties. Pursuant to title 17    |
' | Section 105 of the United States Code. This software is not subject to copyright protection and     |
' | is in the public domain. NIST assumes no responsibility whatsoever for use by other parties of      |
' | its source code or open source server, and makes no guarantees, expressed or implied, about its     |
' | quality, reliability, or any other characteristic.                                                  |
' |                                                                                                     |
' | Specific hardware and software products identified in this open source project were used in order   |
' | to perform technology transfer and collaboration. In no case does such identification imply         |
' | recommendation or endorsement by the National Institute of Standards and Technology, nor            |
' | does it imply that the products and equipment identified are necessarily the best available for the |
' | purpose.                                                                                            |
' •—————————————————————————————————————————————————————————————————————————————————————————————————————•

Option Strict On

Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Imports Mbark.SensorMessages

Imports SF = Syncfusion.Windows.Forms

Imports Mbark.UI

Namespace Mbark.Sensors

    Public Class SensorStatusControl
        Inherits RadioGroupBox
        Implements ISensorControlModeChangeConsumer

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            UserNew()

        End Sub

        'UserControl overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents SensorsGrid As Syncfusion.Windows.Forms.Grid.GridControl
        Friend WithEvents TrimTooltip As System.Windows.Forms.ToolTip
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SensorStatusControl))
            Me.SensorsGrid = New Syncfusion.Windows.Forms.Grid.GridControl
            Me.TrimTooltip = New System.Windows.Forms.ToolTip(Me.components)
            Me.InnerPanel.SuspendLayout()
            CType(Me.SensorsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'InnerPanel
            '
            Me.InnerPanel.Controls.Add(Me.SensorsGrid)
            Me.InnerPanel.Name = "InnerPanel"
            Me.InnerPanel.Size = CType(resources.GetObject("InnerPanel.Size"), System.Drawing.Size)
            '
            'GroupRadioButton
            '
            Me.GroupRadioButton.Name = "GroupRadioButton"
            '
            'SensorsGrid
            '
            Me.SensorsGrid.AccessibleDescription = resources.GetString("SensorsGrid.AccessibleDescription")
            Me.SensorsGrid.AccessibleName = resources.GetString("SensorsGrid.AccessibleName")
            Me.SensorsGrid.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            Me.SensorsGrid.Anchor = CType(resources.GetObject("SensorsGrid.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.SensorsGrid.BackColor = System.Drawing.SystemColors.Control
            Me.SensorsGrid.BackgroundImage = CType(resources.GetObject("SensorsGrid.BackgroundImage"), System.Drawing.Image)
            Me.SensorsGrid.DefaultGridBorderStyle = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
            Me.SensorsGrid.Dock = CType(resources.GetObject("SensorsGrid.Dock"), System.Windows.Forms.DockStyle)
            Me.SensorsGrid.Enabled = CType(resources.GetObject("SensorsGrid.Enabled"), Boolean)
            Me.SensorsGrid.Font = CType(resources.GetObject("SensorsGrid.Font"), System.Drawing.Font)
            Me.SensorsGrid.ForeColor = System.Drawing.SystemColors.Control
            Me.SensorsGrid.ImeMode = CType(resources.GetObject("SensorsGrid.ImeMode"), System.Windows.Forms.ImeMode)
            Me.SensorsGrid.Location = CType(resources.GetObject("SensorsGrid.Location"), System.Drawing.Point)
            Me.SensorsGrid.Name = "SensorsGrid"
            Me.SensorsGrid.NumberedColHeaders = False
            Me.SensorsGrid.NumberedRowHeaders = False
            Me.SensorsGrid.RightToLeft = CType(resources.GetObject("SensorsGrid.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.SensorsGrid.RowCount = 0
            Me.SensorsGrid.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.HideAlways
            Me.SensorsGrid.Size = CType(resources.GetObject("SensorsGrid.Size"), System.Drawing.Size)
            Me.SensorsGrid.SmartSizeBox = False
            Me.SensorsGrid.TabIndex = CType(resources.GetObject("SensorsGrid.TabIndex"), Integer)
            Me.SensorsGrid.Text = resources.GetString("SensorsGrid.Text")
            Me.SensorsGrid.ThemesEnabled = True
            Me.TrimTooltip.SetToolTip(Me.SensorsGrid, resources.GetString("SensorsGrid.ToolTip"))
            Me.SensorsGrid.Visible = CType(resources.GetObject("SensorsGrid.Visible"), Boolean)
            '
            'SensorStatusControl
            '
            Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
            Me.AccessibleName = resources.GetString("$this.AccessibleName")
            Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
            Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
            Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.Name = "SensorStatusControl"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Size = CType(resources.GetObject("$this.Size"), System.Drawing.Size)
            Me.TrimTooltip.SetToolTip(Me, resources.GetString("$this.ToolTip"))
            Me.InnerPanel.ResumeLayout(False)
            CType(Me.SensorsGrid, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

#End Region

        Private Sub UserNew()
            WithFancyHeader = True
        End Sub

        Private Const TextBoxCellType As String = "TextBox"
        Private Const PushButtonCellType As String = "PushButton"
        Private Const ReenableSensorButtonText As String = "Re-enable"

        Private mSensorSetWire As SensorCollection
        Public Sub WireSensorSet(ByVal sensors As SensorCollection)
            mSensorSetWire = sensors
        End Sub

        Public Sub HandleSensorControlModeChange(ByVal sender As Object, ByVal e As SensorControlModeChangeEventArgs) _
        Implements ISensorControlModeChangeConsumer.HandleSensorControlModeChange
            RefreshSensorStatus()
        End Sub

        Public Sub RefreshSensorStatus()
            SafeInvokeNoArgSub(Me, AddressOf RefreshSensorStatusImplementation)
        End Sub

        Private Sub SensorsGrid_CurrentCellShowingDropdown(ByVal sender As Object, ByVal e As SF.Grid.GridCurrentCellShowingDropDownEventArgs) _
        Handles SensorsGrid.CurrentCellShowingDropDown
            e.Cancel = True
        End Sub

        Private mNumberOfSensorsGridIsPreparedFor As Integer
        Private Sub PrepareSensorGridAsNecessary()


            ' See if the number of sensors changed from what we've prepared for
            If mSensorSetWire.Count <> mNumberOfSensorsGridIsPreparedFor Then
                SensorsGrid.RowCount = 2 * mSensorSetWire.Count
                SensorsGrid.RowHeights(0) = 0
            End If

            ' If we haven't expanded the number of sensors, then we're done
            If mSensorSetWire.Count = mNumberOfSensorsGridIsPreparedFor Then Return


            ' Remove extra covered ranges
            For i As Integer = mSensorSetWire.Count To mNumberOfSensorsGridIsPreparedFor
                Dim row As Integer = 2 * i + 1
                SensorsGrid.CoveredRanges.Remove(SF.Grid.GridRangeInfo.Cells(row, ButtonColumnIndex, row, StatusColumnIndex))
                SensorsGrid.CoveredRanges.Remove(SF.Grid.GridRangeInfo.Cells(row, IconColumnIndex, row + 1, IconColumnIndex))
            Next



            For i As Integer = mNumberOfSensorsGridIsPreparedFor To mSensorSetWire.Count - 1

                Dim row As Integer = 2 * i + 1

                SensorsGrid.CoveredRanges.Add(SF.Grid.GridRangeInfo.Cells(row, ButtonColumnIndex, row, StatusColumnIndex))
                SensorsGrid.CoveredRanges.Add(SF.Grid.GridRangeInfo.Cells(row, IconColumnIndex, row + 1, IconColumnIndex))

                Dim border As New SF.Grid.GridBorder(SF.Grid.GridBorderStyle.Solid, SystemColors.ControlDark)

                SensorsGrid(row, IconColumnIndex).Borders.Bottom = border
                SensorsGrid(row + 1, StatusColumnIndex).Borders.Bottom = border
                SensorsGrid(row + 1, ButtonColumnIndex).Borders.Bottom = border


                ' Bump up the row heights a hair
                SensorsGrid.RowHeights(row) = _
                    CInt(1.05! * UI.AutoHeight.FontHeightInPixels(UICulture, NearestForm.CreateGraphics, GlobalUISettings.Defaults.Fonts.Regular))
                SensorsGrid.RowHeights(row + 1) = SensorsGrid.RowHeights(row)



                ' Prepare icon cells
                With SensorsGrid(row, IconColumnIndex)
                    .CellType = TextBoxCellType
                    .TextAlign = SF.Grid.GridTextAlign.Right
                    .ImageList = smGlobeImages
                    .ImageList.ImageSize = New Size(32, 32)
                End With

                ' Prepare name cells
                With SensorsGrid(row, NameColumnIndex)
                    .CellType = TextBoxCellType
                    .Font = New SF.Grid.GridFontInfo(GlobalUISettings.Defaults.Fonts.Bold)
                    .BorderMargins.Top = 0
                    .BorderMargins.Bottom = 0
                    .Trimming = StringTrimming.EllipsisCharacter
                    .WrapText = False
                    .Enabled = False
                End With

                ' Prepare button cells
                With SensorsGrid(row + 1, ButtonColumnIndex)
                    .CellType = PushButtonCellType
                    .Font = New SF.Grid.GridFontInfo(GlobalUISettings.Defaults.Fonts.Small)
                    .BorderMargins.Bottom = 1
                    .BorderMargins.Top = 1
                End With

                ' Prepare status cells
                With SensorsGrid(row + 1, StatusColumnIndex)
                    .CellType = TextBoxCellType
                    .Font = New SF.Grid.GridFontInfo(GlobalUISettings.Defaults.Fonts.Regular)
                    .BorderMargins.Top = 0
                    .BorderMargins.Bottom = 0
                    .Enabled = False
                    .Trimming = StringTrimming.EllipsisCharacter
                    .WrapText = False
                End With
            Next

            mNumberOfSensorsGridIsPreparedFor = mSensorSetWire.Count

        End Sub

        Private Sub RefreshSensorStatusImplementation()

            If NearestForm Is Nothing Then Return
            Dim graphics As graphics = NearestForm.CreateGraphics
            SensorsGrid.BeginUpdate()
            PrepareSensorGridAsNecessary()

            For i As Integer = 0 To mSensorSetWire.Count - 1

                Dim sensor As ISensor = DirectCast(mSensorSetWire(i), ISensor)
                Dim row As Integer = 2 * i + 1

                ' Status icon
                With SensorsGrid(row, IconColumnIndex)
                    .ImageIndex = CInt(sensor.LatestStatus)
                    If sensor.Disabled Then .ImageIndex = 7 ' FRAGILE
                End With

                ' Sensor name
                With SensorsGrid(row, NameColumnIndex)
                    If sensor.DeferInitialization Then
                        .Text = InfrastructureMessages.Messages.Star(UIculture) & sensor.FriendlyName()
                    Else
                        .Text = sensor.FriendlyName()
                    End If
                    UI.RefreshTooltip(graphics, SensorsGrid, row, NameColumnIndex)
                End With

                ' Disable / enable button
                With SensorsGrid(row + 1, ButtonColumnIndex)

                    If sensor.Disabled Then
                        .Description = "Re-enable"
                    Else
                        .Description = "Disable"
                    End If

                    Dim mode As SensorControlMode = SensorControlModeProvider.CurrentSensorControlMode
                    If SensorControlModeSets.DisableSensorPermitted.Contains(mode) Then
                        .TextColor = SystemColors.ControlText
                        .Enabled = True
                        .Clickable = True
                    Else
                        .TextColor = SystemColors.Control
                        .Enabled = False
                        .Clickable = False
                    End If
                End With

                With SensorsGrid(row + 1, StatusColumnIndex)
                    If sensor.Disabled Then
                        .Text = String.Empty
                    Else
                        .Text = sensor.LatestStatus.ToString
                    End If
                    UI.RefreshTooltip(graphics, SensorsGrid, row + 1, StatusColumnIndex)
                End With


            Next
            SensorsGrid.EndUpdate()
            SensorsGrid.Refresh()

        End Sub

        Private mSensorControlModeProvider As ISensorControlModeProvider
        Public ReadOnly Property SensorControlModeProvider() As ISensorControlModeProvider _
        Implements ISensorControlModeChangeConsumer.SensorControlModeProvider
            Get
                If mSensorControlModeProvider Is Nothing Then
                    mSensorControlModeProvider = DirectCast(FindNearestSensorControlModeProviderParent(Me), ISensorControlModeProvider)
                End If
                Return mSensorControlModeProvider
            End Get
        End Property


        Const IconColumnIndex As Integer = 1
        Const ButtonColumnIndex As Integer = 2
        Const StatusColumnIndex As Integer = 3
        Const NameColumnIndex As Integer = 2


        Const NumberOfColumns As Integer = 3
        Const NumberOfHeaderRows As Integer = 0

        Private Shared smGlobeImages As ImageList


        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)

            HeaderText = Messages.Sensors(UICulture)

            If smGlobeImages Is Nothing Then
                smGlobeImages = New ImageList
                smGlobeImages.ColorDepth = ColorDepth.Depth32Bit

                ' HACK : The order here should match the order of the SensorStatus enumeration
                smGlobeImages.Images.Add(New Icon(Me.GetType(), "grey-globe.ico")) 'Uninitialized
                smGlobeImages.Images.Add(New Icon(Me.GetType(), "red-globe.ico"))  'Offline
                smGlobeImages.Images.Add(New Icon(Me.GetType(), "orange-globe.ico")) 'Initializing
                smGlobeImages.Images.Add(New Icon(Me.GetType(), "blue-globe.ico")) 'Capturing
                smGlobeImages.Images.Add(New Icon(Me.GetType(), "darkgreen-globe.ico")) ' Configuring
                smGlobeImages.Images.Add(New Icon(Me.GetType(), "yellow-globe.ico")) 'Downloading
                smGlobeImages.Images.Add(New Icon(Me.GetType(), "green-globe.ico")) 'Online
                smGlobeImages.Images.Add(New Icon(Me.GetType(), "black-globe.ico")) 'Disabled
            End If

            ' Find the nearest provider and handle any session mode changes it produces
            If InDesignMode(Me) Then Return
            SharedImplementation.SubscribeToParentSensorControlModeChangeEvents(Me, True)

            With SensorsGrid
                .ColCount = NumberOfColumns
                With .Properties
                    .RowHeaders = False
                    .ColHeaders = False
                End With
                .HScrollBehavior = SF.Grid.GridScrollbarMode.Disabled
                .RowCount = 0
            End With

        End Sub

        Private Sub SensorGridPushButton_Click(ByVal sender As System.Object, ByVal e As SF.Grid.GridCellPushButtonClickEventArgs) _
        Handles SensorsGrid.PushButtonClick
            If e.ColIndex <> ButtonColumnIndex Then Return

            Dim sensor As ISensor = DirectCast(mSensorSetWire(CInt(e.RowIndex / 2) - 1), ISensor)
            sensor.Disabled = Not sensor.Disabled
            RaiseEvent SensorDisabledChange(Me, New EventArgs)
            RefreshSensorStatus()

        End Sub

        Public Event SensorDisabledChange As EventHandler(Of EventArgs)


        Public Overrides Sub RefreshAutomaticLayout(ByVal graphics As Drawing.Graphics)
            MyBase.RefreshAutomaticLayout(graphics)
            SensorsGrid.ColWidths(1) = 40
            SensorsGrid.ColWidths(2) = 6 * UI.AutoWidth.CharWidthInPixels(UICulture, graphics, SensorsGrid.Font)
            SensorsGrid.ColWidths(3) = SensorsGrid.Width - SensorsGrid.ColWidths(1) - SensorsGrid.ColWidths(2)
        End Sub

        Private mTabList As New Collection(Of Control)
        Public ReadOnly Property TabList() As Collection(Of Control)
            Get
                Return mTabList
            End Get
        End Property

    End Class

End Namespace
