#Region " DATI FILE.VB "
' ***************************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 19/12/2018
' Descrizione:          Anagrafica Azienda.
' Note:
'
' Elenco Attivita:
'
'
' ***************************************************************************************************
#End Region

Option Strict Off
Option Explicit On 

Imports System.IO

Friend Class frmAzienda
   Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
   Public Sub New()
      MyBase.New()
      'Chiamata richiesta dalla progettazione Windows Form.
      InitializeComponent()
      Me.Show()
   End Sub
   'Il form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
      If Disposing Then
         If Not components Is Nothing Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(Disposing)
   End Sub
   'Richiesto dalla progettazione Windows Form
   Private components As System.ComponentModel.IContainer
   'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
   'Può essere modificata utilizzando la finestra di progettazione Windows Form.
   'Non modificarla mediante l'editor di codice.
   Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Public WithEvents chkVisRagSoc As System.Windows.Forms.CheckBox
   Friend WithEvents lblIntestazione As System.Windows.Forms.Label
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
   Public WithEvents txtIBAN As System.Windows.Forms.TextBox
   Public WithEvents Label32 As System.Windows.Forms.Label
   Friend WithEvents cmbPagamento As System.Windows.Forms.ComboBox
   Friend WithEvents Label33 As System.Windows.Forms.Label
   Public WithEvents txtCIN As System.Windows.Forms.TextBox
   Public WithEvents txtCC As System.Windows.Forms.TextBox
   Public WithEvents txtCAB As System.Windows.Forms.TextBox
   Public WithEvents txtABI As System.Windows.Forms.TextBox
   Public WithEvents txtBanca As System.Windows.Forms.TextBox
   Public WithEvents Label34 As System.Windows.Forms.Label
   Public WithEvents Label35 As System.Windows.Forms.Label
   Public WithEvents Label36 As System.Windows.Forms.Label
   Public WithEvents Label37 As System.Windows.Forms.Label
   Public WithEvents Label38 As System.Windows.Forms.Label
   Friend WithEvents EliminaImg As System.Windows.Forms.Button
   Friend WithEvents ApriImg As System.Windows.Forms.Button
   Public WithEvents picFoto As System.Windows.Forms.PictureBox
   Public WithEvents txtIndirizzo As System.Windows.Forms.TextBox
   Public WithEvents txtPIva As System.Windows.Forms.TextBox
   Public WithEvents txtProv As System.Windows.Forms.TextBox
   Public WithEvents txtCap As System.Windows.Forms.TextBox
   Public WithEvents txtCittà As System.Windows.Forms.TextBox
   Public WithEvents txtRagSoc As System.Windows.Forms.TextBox
   Public WithEvents Label31 As System.Windows.Forms.Label
   Public WithEvents Label10 As System.Windows.Forms.Label
   Public WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents Label6 As System.Windows.Forms.Label
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents txtInternet As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents txtMail As System.Windows.Forms.TextBox
   Public WithEvents txtFax As System.Windows.Forms.TextBox
   Public WithEvents txtTel As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents Label21 As System.Windows.Forms.Label
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents tbrSalva As ToolBarButton
   Public WithEvents txtNumeroREA As TextBox
   Public WithEvents Label11 As Label
   Public WithEvents txtCodiceFiscale As TextBox
   Public WithEvents Label8 As Label
   Friend WithEvents cmbRegimeFiscale As ComboBox
   Public WithEvents Label12 As Label
   Friend WithEvents cmbNazione As ComboBox
   Public WithEvents txtPec As TextBox
   Friend WithEvents Label13 As Label
   Friend WithEvents tbrElimina As System.Windows.Forms.ToolBarButton
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAzienda))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.tbrSalva = New System.Windows.Forms.ToolBarButton()
      Me.tbrElimina = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.chkVisRagSoc = New System.Windows.Forms.CheckBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.cmbNazione = New System.Windows.Forms.ComboBox()
      Me.cmbRegimeFiscale = New System.Windows.Forms.ComboBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.txtNumeroREA = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.txtCodiceFiscale = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.EliminaImg = New System.Windows.Forms.Button()
      Me.ApriImg = New System.Windows.Forms.Button()
      Me.picFoto = New System.Windows.Forms.PictureBox()
      Me.txtIndirizzo = New System.Windows.Forms.TextBox()
      Me.txtPIva = New System.Windows.Forms.TextBox()
      Me.txtProv = New System.Windows.Forms.TextBox()
      Me.txtCap = New System.Windows.Forms.TextBox()
      Me.txtCittà = New System.Windows.Forms.TextBox()
      Me.txtRagSoc = New System.Windows.Forms.TextBox()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.TabPage3 = New System.Windows.Forms.TabPage()
      Me.txtInternet = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtMail = New System.Windows.Forms.TextBox()
      Me.txtFax = New System.Windows.Forms.TextBox()
      Me.txtTel = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.TabPage2 = New System.Windows.Forms.TabPage()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.txtIBAN = New System.Windows.Forms.TextBox()
      Me.Label32 = New System.Windows.Forms.Label()
      Me.cmbPagamento = New System.Windows.Forms.ComboBox()
      Me.Label33 = New System.Windows.Forms.Label()
      Me.txtCIN = New System.Windows.Forms.TextBox()
      Me.txtCC = New System.Windows.Forms.TextBox()
      Me.txtCAB = New System.Windows.Forms.TextBox()
      Me.txtABI = New System.Windows.Forms.TextBox()
      Me.txtBanca = New System.Windows.Forms.TextBox()
      Me.Label34 = New System.Windows.Forms.Label()
      Me.Label35 = New System.Windows.Forms.Label()
      Me.Label36 = New System.Windows.Forms.Label()
      Me.Label37 = New System.Windows.Forms.Label()
      Me.Label38 = New System.Windows.Forms.Label()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.txtPec = New System.Windows.Forms.TextBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.Panel1.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage3.SuspendLayout()
      Me.TabPage2.SuspendLayout()
      Me.SuspendLayout()
      '
      'ToolBar1
      '
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbrSalva, Me.tbrElimina})
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(575, 28)
      Me.ToolBar1.TabIndex = 1
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      '
      'tbrSalva
      '
      Me.tbrSalva.ImageIndex = 1
      Me.tbrSalva.Name = "tbrSalva"
      Me.tbrSalva.Tag = "Salva"
      Me.tbrSalva.Text = "Salva e chiudi"
      Me.tbrSalva.ToolTipText = "Salva tutti i dati e chiude la finestra."
      '
      'tbrElimina
      '
      Me.tbrElimina.ImageIndex = 2
      Me.tbrElimina.Name = "tbrElimina"
      Me.tbrElimina.Tag = "Elimina"
      Me.tbrElimina.Text = "Elimina"
      Me.tbrElimina.ToolTipText = "Elimina tutti i dati"
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "DeleteHS.png")
      Me.ImageList1.Images.SetKeyName(1, "Save_Small.png")
      Me.ImageList1.Images.SetKeyName(2, "Delete_Small.png")
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 28)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(575, 20)
      Me.Panel1.TabIndex = 19
      '
      'lblIntestazione
      '
      Me.lblIntestazione.AutoSize = True
      Me.lblIntestazione.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblIntestazione.ForeColor = System.Drawing.SystemColors.Window
      Me.lblIntestazione.Location = New System.Drawing.Point(5, 2)
      Me.lblIntestazione.Name = "lblIntestazione"
      Me.lblIntestazione.Size = New System.Drawing.Size(16, 16)
      Me.lblIntestazione.TabIndex = 0
      Me.lblIntestazione.Text = "#"
      '
      'chkVisRagSoc
      '
      Me.chkVisRagSoc.BackColor = System.Drawing.SystemColors.Control
      Me.chkVisRagSoc.Cursor = System.Windows.Forms.Cursors.Default
      Me.chkVisRagSoc.ForeColor = System.Drawing.SystemColors.Desktop
      Me.chkVisRagSoc.Location = New System.Drawing.Point(104, 360)
      Me.chkVisRagSoc.Name = "chkVisRagSoc"
      Me.chkVisRagSoc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.chkVisRagSoc.Size = New System.Drawing.Size(400, 16)
      Me.chkVisRagSoc.TabIndex = 11
      Me.chkVisRagSoc.Text = "Visualizzare la ragione sociale nella barra di intestazione dell'applicazione"
      Me.chkVisRagSoc.UseVisualStyleBackColor = False
      Me.chkVisRagSoc.Visible = False
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.TabPage1)
      Me.TabControl1.Controls.Add(Me.TabPage3)
      Me.TabControl1.Controls.Add(Me.TabPage2)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 48)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(575, 343)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.cmbNazione)
      Me.TabPage1.Controls.Add(Me.cmbRegimeFiscale)
      Me.TabPage1.Controls.Add(Me.Label12)
      Me.TabPage1.Controls.Add(Me.txtNumeroREA)
      Me.TabPage1.Controls.Add(Me.Label11)
      Me.TabPage1.Controls.Add(Me.txtCodiceFiscale)
      Me.TabPage1.Controls.Add(Me.Label8)
      Me.TabPage1.Controls.Add(Me.EliminaImg)
      Me.TabPage1.Controls.Add(Me.ApriImg)
      Me.TabPage1.Controls.Add(Me.picFoto)
      Me.TabPage1.Controls.Add(Me.txtIndirizzo)
      Me.TabPage1.Controls.Add(Me.txtPIva)
      Me.TabPage1.Controls.Add(Me.txtProv)
      Me.TabPage1.Controls.Add(Me.txtCap)
      Me.TabPage1.Controls.Add(Me.txtCittà)
      Me.TabPage1.Controls.Add(Me.txtRagSoc)
      Me.TabPage1.Controls.Add(Me.Label31)
      Me.TabPage1.Controls.Add(Me.Label10)
      Me.TabPage1.Controls.Add(Me.Label9)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.ForeColor = System.Drawing.SystemColors.Desktop
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(567, 317)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Tag = "Codice fornito da Azienda emettitrice di Buoni pasto:"
      Me.TabPage1.Text = "Dati principali"
      Me.TabPage1.ToolTipText = "Dati principali"
      '
      'cmbNazione
      '
      Me.cmbNazione.Location = New System.Drawing.Point(104, 218)
      Me.cmbNazione.Name = "cmbNazione"
      Me.cmbNazione.Size = New System.Drawing.Size(160, 21)
      Me.cmbNazione.TabIndex = 216
      '
      'cmbRegimeFiscale
      '
      Me.cmbRegimeFiscale.BackColor = System.Drawing.SystemColors.Window
      Me.cmbRegimeFiscale.Cursor = System.Windows.Forms.Cursors.Default
      Me.cmbRegimeFiscale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRegimeFiscale.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cmbRegimeFiscale.Items.AddRange(New Object() {" ", "RF01 Ordinario", "RF02 Contribuenti minimi (art. 1, c.96-117, L. 244/2007)", "RF04 Agricoltura e attività connesse e pesca (artt. 34 e 34-bis, D.P.R. 633/1972)" &
                "", "RF05 Vendita sali e tabacchi (art. 74, c.1, D.P.R. 633/1972)", "RF06 Commercio dei fiammiferi (art. 74, c.1, D.P.R. 633/1972)", "RF07 Editoria (art. 74, c.1, D.P.R. 633/1972)", "RF08 Gestione di servizi di telefonia pubblica (art. 74, c.1, D.P.R. 633/1972)", "RF09 Rivendita di documenti di trasporto pubblico e di sosta (art. 74, c.1, D.P.R" &
                ". 633/1972)", "RF10 Intrattenimenti, giochi e altre attività di cui alla tariffa allegata al D.P" &
                ".R. n. 640/72 (art. 74, c.6, D.P.R. 633/1972)", "RF11 Agenzie di viaggi e turismo (art. 74-ter, D.P.R. 633/1972)", "RF12 Agriturismo (art. 5, c.2, L. 413/1991)", "RF13 Vendite a domicilio (art. 25-bis, c.6, D.P.R. 600/1973)", "RF14 Rivendita di beni usati, di oggetti d’arte, d’antiquariato o da collezione (" &
                "art. 36, D.L. 41/1995)", "RF15 Agenzie di vendite all’asta di oggetti d’arte, antiquariato o da collezione " &
                "(art. 40-bis, D.L. 41/1995)", "RF16 IVA per cassa P.A. (art. 6, c.5, D.P.R. 633/1972)", "RF17 IVA per cassa (art. 32-bis, D.L. 83/2012)", "RF18 Altro", "RF19 Forfettario (art.1, c. 54-89, L. 190/2014)"})
      Me.cmbRegimeFiscale.Location = New System.Drawing.Point(104, 251)
      Me.cmbRegimeFiscale.Name = "cmbRegimeFiscale"
      Me.cmbRegimeFiscale.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.cmbRegimeFiscale.Size = New System.Drawing.Size(416, 21)
      Me.cmbRegimeFiscale.TabIndex = 9
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(16, 251)
      Me.Label12.Name = "Label12"
      Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label12.Size = New System.Drawing.Size(82, 13)
      Me.Label12.TabIndex = 215
      Me.Label12.Text = "Regime Fiscale:"
      '
      'txtNumeroREA
      '
      Me.txtNumeroREA.AcceptsReturn = True
      Me.txtNumeroREA.BackColor = System.Drawing.SystemColors.Window
      Me.txtNumeroREA.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumeroREA.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNumeroREA.Location = New System.Drawing.Point(104, 108)
      Me.txtNumeroREA.MaxLength = 20
      Me.txtNumeroREA.Name = "txtNumeroREA"
      Me.txtNumeroREA.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumeroREA.Size = New System.Drawing.Size(160, 20)
      Me.txtNumeroREA.TabIndex = 3
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(16, 108)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(81, 13)
      Me.Label11.TabIndex = 213
      Me.Label11.Text = "Numero R.E.A.:"
      '
      'txtCodiceFiscale
      '
      Me.txtCodiceFiscale.AcceptsReturn = True
      Me.txtCodiceFiscale.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodiceFiscale.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodiceFiscale.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCodiceFiscale.Location = New System.Drawing.Point(104, 82)
      Me.txtCodiceFiscale.MaxLength = 16
      Me.txtCodiceFiscale.Name = "txtCodiceFiscale"
      Me.txtCodiceFiscale.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodiceFiscale.Size = New System.Drawing.Size(160, 20)
      Me.txtCodiceFiscale.TabIndex = 2
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(16, 82)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(79, 13)
      Me.Label8.TabIndex = 211
      Me.Label8.Text = "Codice Fiscale:"
      '
      'EliminaImg
      '
      Me.EliminaImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.EliminaImg.Location = New System.Drawing.Point(447, 184)
      Me.EliminaImg.Name = "EliminaImg"
      Me.EliminaImg.Size = New System.Drawing.Size(72, 24)
      Me.EliminaImg.TabIndex = 11
      Me.EliminaImg.Text = "&Elimina"
      '
      'ApriImg
      '
      Me.ApriImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ApriImg.Location = New System.Drawing.Point(367, 184)
      Me.ApriImg.Name = "ApriImg"
      Me.ApriImg.Size = New System.Drawing.Size(72, 24)
      Me.ApriImg.TabIndex = 10
      Me.ApriImg.Text = "&Apri"
      '
      'picFoto
      '
      Me.picFoto.BackColor = System.Drawing.Color.White
      Me.picFoto.Cursor = System.Windows.Forms.Cursors.Default
      Me.picFoto.Location = New System.Drawing.Point(367, 24)
      Me.picFoto.Name = "picFoto"
      Me.picFoto.Size = New System.Drawing.Size(153, 153)
      Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picFoto.TabIndex = 209
      Me.picFoto.TabStop = False
      '
      'txtIndirizzo
      '
      Me.txtIndirizzo.AcceptsReturn = True
      Me.txtIndirizzo.BackColor = System.Drawing.SystemColors.Window
      Me.txtIndirizzo.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIndirizzo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIndirizzo.Location = New System.Drawing.Point(104, 140)
      Me.txtIndirizzo.MaxLength = 100
      Me.txtIndirizzo.Name = "txtIndirizzo"
      Me.txtIndirizzo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIndirizzo.Size = New System.Drawing.Size(248, 20)
      Me.txtIndirizzo.TabIndex = 4
      '
      'txtPIva
      '
      Me.txtPIva.AcceptsReturn = True
      Me.txtPIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtPIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPIva.Location = New System.Drawing.Point(104, 56)
      Me.txtPIva.MaxLength = 11
      Me.txtPIva.Name = "txtPIva"
      Me.txtPIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPIva.Size = New System.Drawing.Size(160, 20)
      Me.txtPIva.TabIndex = 1
      '
      'txtProv
      '
      Me.txtProv.AcceptsReturn = True
      Me.txtProv.BackColor = System.Drawing.SystemColors.Window
      Me.txtProv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtProv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtProv.Location = New System.Drawing.Point(104, 192)
      Me.txtProv.MaxLength = 2
      Me.txtProv.Name = "txtProv"
      Me.txtProv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtProv.Size = New System.Drawing.Size(56, 20)
      Me.txtProv.TabIndex = 6
      '
      'txtCap
      '
      Me.txtCap.AcceptsReturn = True
      Me.txtCap.BackColor = System.Drawing.SystemColors.Window
      Me.txtCap.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCap.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCap.Location = New System.Drawing.Point(264, 192)
      Me.txtCap.MaxLength = 5
      Me.txtCap.Name = "txtCap"
      Me.txtCap.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCap.Size = New System.Drawing.Size(88, 20)
      Me.txtCap.TabIndex = 7
      '
      'txtCittà
      '
      Me.txtCittà.AcceptsReturn = True
      Me.txtCittà.BackColor = System.Drawing.SystemColors.Window
      Me.txtCittà.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCittà.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCittà.Location = New System.Drawing.Point(104, 166)
      Me.txtCittà.MaxLength = 100
      Me.txtCittà.Name = "txtCittà"
      Me.txtCittà.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCittà.Size = New System.Drawing.Size(248, 20)
      Me.txtCittà.TabIndex = 5
      '
      'txtRagSoc
      '
      Me.txtRagSoc.AcceptsReturn = True
      Me.txtRagSoc.BackColor = System.Drawing.SystemColors.Window
      Me.txtRagSoc.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtRagSoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRagSoc.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtRagSoc.Location = New System.Drawing.Point(104, 24)
      Me.txtRagSoc.MaxLength = 50
      Me.txtRagSoc.Name = "txtRagSoc"
      Me.txtRagSoc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtRagSoc.Size = New System.Drawing.Size(248, 20)
      Me.txtRagSoc.TabIndex = 0
      '
      'Label31
      '
      Me.Label31.AutoSize = True
      Me.Label31.BackColor = System.Drawing.Color.Transparent
      Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label31.ForeColor = System.Drawing.Color.Black
      Me.Label31.Location = New System.Drawing.Point(16, 56)
      Me.Label31.Name = "Label31"
      Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label31.Size = New System.Drawing.Size(69, 13)
      Me.Label31.TabIndex = 206
      Me.Label31.Text = "Partita I.V.A.:"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(16, 218)
      Me.Label10.Name = "Label10"
      Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label10.Size = New System.Drawing.Size(49, 13)
      Me.Label10.TabIndex = 204
      Me.Label10.Text = "Nazione:"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(16, 192)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(54, 13)
      Me.Label9.TabIndex = 203
      Me.Label9.Text = "Provincia:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(224, 192)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(40, 13)
      Me.Label6.TabIndex = 202
      Me.Label6.Text = "C.A.P.:"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(16, 166)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(31, 13)
      Me.Label5.TabIndex = 201
      Me.Label5.Text = "Città:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(16, 140)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(48, 13)
      Me.Label4.TabIndex = 200
      Me.Label4.Text = "Indirizzo:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(16, 24)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(86, 13)
      Me.Label3.TabIndex = 199
      Me.Label3.Text = "Ragione sociale:"
      '
      'TabPage3
      '
      Me.TabPage3.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage3.Controls.Add(Me.txtPec)
      Me.TabPage3.Controls.Add(Me.Label13)
      Me.TabPage3.Controls.Add(Me.txtInternet)
      Me.TabPage3.Controls.Add(Me.Label2)
      Me.TabPage3.Controls.Add(Me.txtMail)
      Me.TabPage3.Controls.Add(Me.txtFax)
      Me.TabPage3.Controls.Add(Me.txtTel)
      Me.TabPage3.Controls.Add(Me.Label7)
      Me.TabPage3.Controls.Add(Me.Label1)
      Me.TabPage3.Controls.Add(Me.Label21)
      Me.TabPage3.Location = New System.Drawing.Point(4, 22)
      Me.TabPage3.Name = "TabPage3"
      Me.TabPage3.Size = New System.Drawing.Size(567, 317)
      Me.TabPage3.TabIndex = 2
      Me.TabPage3.Text = "Tel./Internet"
      Me.TabPage3.ToolTipText = "Dati sul telefono e Internet"
      Me.TabPage3.Visible = False
      '
      'txtInternet
      '
      Me.txtInternet.AcceptsReturn = True
      Me.txtInternet.BackColor = System.Drawing.SystemColors.Window
      Me.txtInternet.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtInternet.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtInternet.Location = New System.Drawing.Point(112, 133)
      Me.txtInternet.MaxLength = 0
      Me.txtInternet.Name = "txtInternet"
      Me.txtInternet.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtInternet.Size = New System.Drawing.Size(248, 20)
      Me.txtInternet.TabIndex = 4
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(24, 133)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(46, 13)
      Me.Label2.TabIndex = 218
      Me.Label2.Text = "Internet:"
      '
      'txtMail
      '
      Me.txtMail.AcceptsReturn = True
      Me.txtMail.BackColor = System.Drawing.SystemColors.Window
      Me.txtMail.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtMail.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtMail.Location = New System.Drawing.Point(112, 80)
      Me.txtMail.MaxLength = 0
      Me.txtMail.Name = "txtMail"
      Me.txtMail.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtMail.Size = New System.Drawing.Size(248, 20)
      Me.txtMail.TabIndex = 2
      '
      'txtFax
      '
      Me.txtFax.AcceptsReturn = True
      Me.txtFax.BackColor = System.Drawing.SystemColors.Window
      Me.txtFax.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtFax.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtFax.Location = New System.Drawing.Point(112, 48)
      Me.txtFax.MaxLength = 15
      Me.txtFax.Name = "txtFax"
      Me.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtFax.Size = New System.Drawing.Size(160, 20)
      Me.txtFax.TabIndex = 1
      '
      'txtTel
      '
      Me.txtTel.AcceptsReturn = True
      Me.txtTel.BackColor = System.Drawing.SystemColors.Window
      Me.txtTel.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTel.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtTel.Location = New System.Drawing.Point(112, 24)
      Me.txtTel.MaxLength = 15
      Me.txtTel.Name = "txtTel"
      Me.txtTel.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTel.Size = New System.Drawing.Size(160, 20)
      Me.txtTel.TabIndex = 0
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(24, 80)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(39, 13)
      Me.Label7.TabIndex = 217
      Me.Label7.Text = "E-Mail:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(24, 48)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(27, 13)
      Me.Label1.TabIndex = 216
      Me.Label1.Text = "Fax:"
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.BackColor = System.Drawing.Color.Transparent
      Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label21.ForeColor = System.Drawing.Color.Black
      Me.Label21.Location = New System.Drawing.Point(24, 24)
      Me.Label21.Name = "Label21"
      Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label21.Size = New System.Drawing.Size(52, 13)
      Me.Label21.TabIndex = 215
      Me.Label21.Text = "Telefono:"
      '
      'TabPage2
      '
      Me.TabPage2.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage2.Controls.Add(Me.Button1)
      Me.TabPage2.Controls.Add(Me.txtIBAN)
      Me.TabPage2.Controls.Add(Me.Label32)
      Me.TabPage2.Controls.Add(Me.cmbPagamento)
      Me.TabPage2.Controls.Add(Me.Label33)
      Me.TabPage2.Controls.Add(Me.txtCIN)
      Me.TabPage2.Controls.Add(Me.txtCC)
      Me.TabPage2.Controls.Add(Me.txtCAB)
      Me.TabPage2.Controls.Add(Me.txtABI)
      Me.TabPage2.Controls.Add(Me.txtBanca)
      Me.TabPage2.Controls.Add(Me.Label34)
      Me.TabPage2.Controls.Add(Me.Label35)
      Me.TabPage2.Controls.Add(Me.Label36)
      Me.TabPage2.Controls.Add(Me.Label37)
      Me.TabPage2.Controls.Add(Me.Label38)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Size = New System.Drawing.Size(559, 309)
      Me.TabPage2.TabIndex = 6
      Me.TabPage2.Text = "Modalità pagamento"
      Me.TabPage2.Visible = False
      '
      'Button1
      '
      Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.Button1.Location = New System.Drawing.Point(408, 192)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(64, 24)
      Me.Button1.TabIndex = 55721
      Me.Button1.Text = "Button1"
      Me.Button1.Visible = False
      '
      'txtIBAN
      '
      Me.txtIBAN.AcceptsReturn = True
      Me.txtIBAN.BackColor = System.Drawing.SystemColors.Window
      Me.txtIBAN.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIBAN.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIBAN.Location = New System.Drawing.Point(120, 192)
      Me.txtIBAN.MaxLength = 0
      Me.txtIBAN.Name = "txtIBAN"
      Me.txtIBAN.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIBAN.Size = New System.Drawing.Size(260, 20)
      Me.txtIBAN.TabIndex = 6
      '
      'Label32
      '
      Me.Label32.AutoSize = True
      Me.Label32.BackColor = System.Drawing.Color.Transparent
      Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label32.ForeColor = System.Drawing.Color.Black
      Me.Label32.Location = New System.Drawing.Point(32, 192)
      Me.Label32.Name = "Label32"
      Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label32.Size = New System.Drawing.Size(35, 13)
      Me.Label32.TabIndex = 55720
      Me.Label32.Text = "IBAN:"
      '
      'cmbPagamento
      '
      Me.cmbPagamento.Location = New System.Drawing.Point(120, 32)
      Me.cmbPagamento.Name = "cmbPagamento"
      Me.cmbPagamento.Size = New System.Drawing.Size(312, 21)
      Me.cmbPagamento.TabIndex = 0
      '
      'Label33
      '
      Me.Label33.AutoSize = True
      Me.Label33.ForeColor = System.Drawing.Color.Black
      Me.Label33.Location = New System.Drawing.Point(32, 32)
      Me.Label33.Name = "Label33"
      Me.Label33.Size = New System.Drawing.Size(87, 13)
      Me.Label33.TabIndex = 55718
      Me.Label33.Text = "Tipo pagamento:"
      '
      'txtCIN
      '
      Me.txtCIN.AcceptsReturn = True
      Me.txtCIN.BackColor = System.Drawing.SystemColors.Window
      Me.txtCIN.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCIN.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCIN.Location = New System.Drawing.Point(120, 168)
      Me.txtCIN.MaxLength = 1
      Me.txtCIN.Name = "txtCIN"
      Me.txtCIN.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCIN.Size = New System.Drawing.Size(40, 20)
      Me.txtCIN.TabIndex = 5
      '
      'txtCC
      '
      Me.txtCC.AcceptsReturn = True
      Me.txtCC.BackColor = System.Drawing.SystemColors.Window
      Me.txtCC.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCC.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCC.Location = New System.Drawing.Point(120, 136)
      Me.txtCC.MaxLength = 12
      Me.txtCC.Name = "txtCC"
      Me.txtCC.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCC.Size = New System.Drawing.Size(144, 20)
      Me.txtCC.TabIndex = 4
      '
      'txtCAB
      '
      Me.txtCAB.AcceptsReturn = True
      Me.txtCAB.BackColor = System.Drawing.SystemColors.Window
      Me.txtCAB.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCAB.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCAB.Location = New System.Drawing.Point(120, 112)
      Me.txtCAB.MaxLength = 5
      Me.txtCAB.Name = "txtCAB"
      Me.txtCAB.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCAB.Size = New System.Drawing.Size(144, 20)
      Me.txtCAB.TabIndex = 3
      '
      'txtABI
      '
      Me.txtABI.AcceptsReturn = True
      Me.txtABI.BackColor = System.Drawing.SystemColors.Window
      Me.txtABI.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtABI.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtABI.Location = New System.Drawing.Point(120, 88)
      Me.txtABI.MaxLength = 5
      Me.txtABI.Name = "txtABI"
      Me.txtABI.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtABI.Size = New System.Drawing.Size(144, 20)
      Me.txtABI.TabIndex = 2
      '
      'txtBanca
      '
      Me.txtBanca.AcceptsReturn = True
      Me.txtBanca.BackColor = System.Drawing.SystemColors.Window
      Me.txtBanca.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtBanca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtBanca.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtBanca.Location = New System.Drawing.Point(120, 64)
      Me.txtBanca.MaxLength = 50
      Me.txtBanca.Name = "txtBanca"
      Me.txtBanca.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtBanca.Size = New System.Drawing.Size(312, 20)
      Me.txtBanca.TabIndex = 1
      '
      'Label34
      '
      Me.Label34.AutoSize = True
      Me.Label34.BackColor = System.Drawing.Color.Transparent
      Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label34.ForeColor = System.Drawing.Color.Black
      Me.Label34.Location = New System.Drawing.Point(32, 168)
      Me.Label34.Name = "Label34"
      Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label34.Size = New System.Drawing.Size(28, 13)
      Me.Label34.TabIndex = 176
      Me.Label34.Text = "CIN:"
      '
      'Label35
      '
      Me.Label35.AutoSize = True
      Me.Label35.BackColor = System.Drawing.Color.Transparent
      Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label35.ForeColor = System.Drawing.Color.Black
      Me.Label35.Location = New System.Drawing.Point(32, 136)
      Me.Label35.Name = "Label35"
      Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label35.Size = New System.Drawing.Size(29, 13)
      Me.Label35.TabIndex = 175
      Me.Label35.Text = "C/C:"
      '
      'Label36
      '
      Me.Label36.AutoSize = True
      Me.Label36.BackColor = System.Drawing.Color.Transparent
      Me.Label36.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label36.ForeColor = System.Drawing.Color.Black
      Me.Label36.Location = New System.Drawing.Point(32, 112)
      Me.Label36.Name = "Label36"
      Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label36.Size = New System.Drawing.Size(31, 13)
      Me.Label36.TabIndex = 174
      Me.Label36.Text = "CAB:"
      '
      'Label37
      '
      Me.Label37.AutoSize = True
      Me.Label37.BackColor = System.Drawing.Color.Transparent
      Me.Label37.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label37.ForeColor = System.Drawing.Color.Black
      Me.Label37.Location = New System.Drawing.Point(32, 88)
      Me.Label37.Name = "Label37"
      Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label37.Size = New System.Drawing.Size(27, 13)
      Me.Label37.TabIndex = 173
      Me.Label37.Text = "ABI:"
      '
      'Label38
      '
      Me.Label38.AutoSize = True
      Me.Label38.BackColor = System.Drawing.Color.Transparent
      Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label38.ForeColor = System.Drawing.Color.Black
      Me.Label38.Location = New System.Drawing.Point(32, 64)
      Me.Label38.Name = "Label38"
      Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label38.Size = New System.Drawing.Size(41, 13)
      Me.Label38.TabIndex = 172
      Me.Label38.Text = "Banca:"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'txtPec
      '
      Me.txtPec.AcceptsReturn = True
      Me.txtPec.BackColor = System.Drawing.SystemColors.Window
      Me.txtPec.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPec.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPec.Location = New System.Drawing.Point(112, 106)
      Me.txtPec.MaxLength = 0
      Me.txtPec.Name = "txtPec"
      Me.txtPec.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPec.Size = New System.Drawing.Size(248, 20)
      Me.txtPec.TabIndex = 3
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.Color.Transparent
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.ForeColor = System.Drawing.Color.Black
      Me.Label13.Location = New System.Drawing.Point(24, 106)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(31, 13)
      Me.Label13.TabIndex = 220
      Me.Label13.Text = "PEC:"
      '
      'frmAzienda
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(575, 391)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.chkVisRagSoc)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Cursor = System.Windows.Forms.Cursors.Default
      Me.ForeColor = System.Drawing.Color.Black
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Location = New System.Drawing.Point(81, 63)
      Me.Name = "frmAzienda"
      Me.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.ShowInTaskbar = False
      Me.Tag = ""
      Me.Text = "Dati generali Azienda"
      Me.TransparencyKey = System.Drawing.Color.White
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage3.ResumeLayout(False)
      Me.TabPage3.PerformLayout()
      Me.TabPage2.ResumeLayout(False)
      Me.TabPage2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
#End Region

   Const NOME_TABELLA As String = "Azienda"
   Const TAB_NAZIONI As String = "Nazioni"
   Const TAB_PAGAMENTO As String = "ModPagamento"

   'Public PercorsoLogo As String = ""

   Private AAzienda As New Anagrafiche.Azienda(ConnString)
   Private CConvalida As New ConvalidaKeyPress

   Private Sub Salva()
      Try
         ' Aggiorna le tabelle dati da eventuali valori inseriti.
         AggiornaTabella(cmbNazione, TAB_NAZIONI)
         AggiornaTabella(cmbPagamento, TAB_PAGAMENTO)

         ' Salva i dati eventualmente modificati.
         AAzienda.RagSociale = txtRagSoc.Text ' FormattaApici(txtRagSoc.Text)
         AAzienda.Piva = FormattaApici(txtPIva.Text)
         AAzienda.CodFisc = FormattaApici(txtCodiceFiscale.Text)
         AAzienda.Rea = FormattaApici(txtNumeroREA.Text)
         AAzienda.Indirizzo = FormattaApici(txtIndirizzo.Text)
         AAzienda.Cap = FormattaApici(txtCap.Text)
         AAzienda.Città = FormattaApici(txtCittà.Text)
         AAzienda.Provincia = FormattaApici(txtProv.Text)
         AAzienda.Nazione = FormattaApici(cmbNazione.Text)
         AAzienda.RegimeFiscale = FormattaApici(cmbRegimeFiscale.Text)
         AAzienda.Telefono = FormattaApici(txtTel.Text)
         AAzienda.Fax = FormattaApici(txtFax.Text)
         AAzienda.Email = FormattaApici(txtMail.Text)
         AAzienda.PEC = FormattaApici(txtPec.Text)
         AAzienda.Internet = FormattaApici(txtInternet.Text)
         AAzienda.TipoPagamento = FormattaApici(cmbPagamento.Text)
         AAzienda.Banca = FormattaApici(txtBanca.Text)
         AAzienda.Abi = FormattaApici(txtABI.Text)
         AAzienda.Cab = FormattaApici(txtCAB.Text)
         AAzienda.Cc = FormattaApici(txtCC.Text)
         AAzienda.Cin = FormattaApici(txtCIN.Text)
         AAzienda.Iban = FormattaApici(txtIBAN.Text)

         AAzienda.ModificaDati(NOME_TABELLA, AAzienda.Codice)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Elimina()
      Try
         ' Svuota tutte le caselle di testo da eventuali valori.
         txtRagSoc.Text = String.Empty
         txtPIva.Text = String.Empty
         txtCodiceFiscale.Text = String.Empty
         txtNumeroREA.Text = String.Empty
         txtIndirizzo.Text = String.Empty
         txtCap.Text = String.Empty
         txtCittà.Text = String.Empty
         txtProv.Text = String.Empty
         cmbNazione.Text = String.Empty
         cmbRegimeFiscale.Text = String.Empty
         txtTel.Text = String.Empty
         txtFax.Text = String.Empty
         txtMail.Text = String.Empty
         txtInternet.Text = String.Empty

         EliminaImmagine()

         ' Salva i dati modificati ed esce dal form.
         Salva()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      ' Imposta le dimensioni standard del form.
      Me.Width = larghezza
      Me.Height = altezza
   End Sub

   Private Sub InserisciImmagine()
      Try
         OpenFileDialog1.Filter = "Tutti i formati |*.Bmp; *.Gif; *.Jpg; *.Jpeg; *.Png; *.Tga; *.Tiff; *.Wmf|" &
                                  "Bmp (Bitmap di Windows)|*.Bmp|" &
                                  "Gif |*.Gif|" &
                                  "Jpeg/Jpg |*.Jpg; *.Jpeg |" &
                                  "Png |*.Png|" &
                                  "Tga |*.Tga|" &
                                  "Tiff |*.Tiff|" &
                                  "Wmf (Metafile di Windows) |*.Wmf"

         OpenFileDialog1.FilterIndex = 1

         If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            AAzienda.PercorsoImg = OpenFileDialog1.FileName
            ' Salva l'immagine in un campo BLOB del database.
            AAzienda.Immagine = CreaStream(OpenFileDialog1.FileName)

            If File.Exists(OpenFileDialog1.FileName) = True Then
               Dim bmp As New Bitmap(OpenFileDialog1.FileName)
               picFoto.Image = bmp
               bmp = Nothing
            End If

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub EliminaImmagine()
      Try
         If Not (picFoto.Image Is Nothing) Then
            picFoto.Image.Dispose()
            picFoto.Image = Nothing
            AAzienda.Immagine = CreaStream(Application.StartupPath & PERCORSO_IMG_LOGO)
            AAzienda.PercorsoImg = Application.StartupPath & PERCORSO_IMG_LOGO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ImpostaFunzioniOperatore(ByVal wnd As String)
      Try
         Select Case wnd
            Case Finestra.DatiAzienda
               If operatore.AnagDatiAzienda = VALORE_LETTURA Then
                  tbrElimina.Enabled = False
                  TabPage1.Enabled = False
                  TabPage2.Enabled = False
                  TabPage3.Enabled = False
               Else
                  tbrElimina.Enabled = True
                  TabPage1.Enabled = True
                  TabPage2.Enabled = True
                  TabPage3.Enabled = True
               End If
         End Select


      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub frmAzienda_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
      ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgGestionaleAmica.Visible = True

   End Sub

   Private Sub frmAzienda_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
      Dim tempFile As String = Application.StartupPath & "\temp.bmp"

      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)


         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         ' Imposta le dimensioni del form.
         FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

         ' Visualizza i dati nei rispettivi campi.
         AAzienda.LeggiDati(NOME_TABELLA)

         ' Assegna i dati dei campi della classe alle caselle di testo.
         txtRagSoc.Text = AAzienda.RagSociale
         txtPIva.Text = AAzienda.Piva
         txtCodiceFiscale.Text = AAzienda.CodFisc
         txtNumeroREA.Text = AAzienda.Rea
         txtIndirizzo.Text = AAzienda.Indirizzo
         txtCap.Text = AAzienda.Cap
         txtCittà.Text = AAzienda.Città
         txtProv.Text = AAzienda.Provincia
         cmbNazione.Text = AAzienda.Nazione
         cmbRegimeFiscale.Text = AAzienda.RegimeFiscale
         txtTel.Text = AAzienda.Telefono
         txtFax.Text = AAzienda.Fax
         txtMail.Text = AAzienda.Email
         txtPec.Text = AAzienda.PEC
         txtInternet.Text = AAzienda.Internet
         cmbPagamento.Text = AAzienda.TipoPagamento
         txtBanca.Text = AAzienda.Banca
         txtABI.Text = AAzienda.Abi
         txtCAB.Text = AAzienda.Cab
         txtCC.Text = AAzienda.Cc
         txtCIN.Text = AAzienda.Cin
         txtIBAN.Text = AAzienda.Iban

         If AAzienda.PercorsoImg <> Nothing Then
            If File.Exists(AAzienda.PercorsoImg) = True Then
               Dim bmp As New Bitmap(AAzienda.PercorsoImg)
               picFoto.Image = bmp
            End If
         End If

         ' Carica la lista del campo Nazioni.
         CaricaLista(cmbNazione, TAB_NAZIONI)
         CaricaLista(cmbPagamento, TAB_PAGAMENTO)

         ' Visualizza la ragione sociale nell'intestazione.
         lblIntestazione.Text = txtRagSoc.Text.ToUpper

         ' Attiva/disattiva i comandi in base ai permessi dell'operatore.
         ImpostaFunzioniOperatore(Finestra.DatiAzienda)

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_ANAGRAFICA_DATI_AZIENDA, MODULO_ANAGRAFICA_DATI_AZIENDA)

         ' Imposta lo stato attivo.
         txtRagSoc.Focus()

      Catch ex As OutOfMemoryException
         picFoto.Image = Image.FromFile(tempFile)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmAzienda_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         ' Salva i dati modificati ed esce dal form.
         Salva()

         ' Visualizza il nome dell'azienda sulla barra di stato.
         g_frmMain.eui_cmdAzienda.Text = AAzienda.RagSociale

         Dim descrizione As String = "(" & AAzienda.RagSociale & ")"

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Salva, descrizione, MODULO_ANAGRAFICA_DATI_AZIENDA)

         ' Effetto scomparsa verso il basso.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmAzienda)

         ' Distrugge gli oggetti e libera le risorse.
         g_frmAzienda.Dispose()
         g_frmAzienda = Nothing
         AAzienda = Nothing

         ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
         g_frmMain.rtgGestionaleAmica.Visible = False

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_ANAGRAFICA_DATI_AZIENDA, MODULO_ANAGRAFICA_DATI_AZIENDA)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i data e chiude il form.
            Me.Close()

         Case "Elimina"
            Dim descrizione As String = "(" & AAzienda.RagSociale & ")"

            ' Svuota tutti i campi e salva i dati.
            Elimina()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Elimina, descrizione, MODULO_ANAGRAFICA_DATI_AZIENDA)
      End Select
   End Sub

   Private Sub txtRagSoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' Visualizza la ragione sociale nell'intestazione del form.
      lblIntestazione.Text = txtRagSoc.Text.ToUpper
   End Sub

   Protected Overrides Sub Finalize()
      MyBase.Finalize()
   End Sub

   Private Sub ApriImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApriImg.Click
      InserisciImmagine()
   End Sub

   Private Sub EliminaImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminaImg.Click
      ApriImg.NotifyDefault(False)
      EliminaImmagine()
   End Sub

   Private Sub txtPIva_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtCap_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtTel_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtFax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Try
         Select Case TabControl1.SelectedIndex()
            Case 0
               ' Imposta lo stato attivo.
               txtRagSoc.Focus()

            Case 1
               ' Imposta lo stato attivo.
               txtTel.Focus()

            Case 2
               ' Imposta lo stato attivo.
               cmbPagamento.Focus()
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      If (txtCC.Text.Length > 12) Then
         'Lunghezza errata
         Exit Sub
      Else
         Dim IBAN As New CalcolaIBAN
         IBAN.Abi = txtABI.Text
         IBAN.Cab = txtCAB.Text
         IBAN.ContoCorrente = txtCC.Text
         IBAN.Paese = "IT"

         txtCIN.Text = IBAN.CalcolaCin()
         txtIBAN.Text = IBAN.CalcolaIBAN()
         'Dim sCheck As String = String.Empty
         'sCheck = IBAN.CalcolaCheckIBAN(paese, IBAN.CalcolaBBAN())

      End If

   End Sub

End Class