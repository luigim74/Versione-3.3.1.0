﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFatturaElettronica
   Inherits System.Windows.Forms.Form

   'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Richiesto da Progettazione Windows Form
   Private components As System.ComponentModel.IContainer

   'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla mediante l'editor del codice.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFatturaElettronica))
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.StatusBar1 = New Elegant.Ui.StatusBar()
      Me.StatusBarNotificationsArea1 = New Elegant.Ui.StatusBarNotificationsArea()
      Me.StatusBarPane2 = New Elegant.Ui.StatusBarPane()
      Me.Label1 = New Elegant.Ui.Label()
      Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
      Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
      Me.StatusBarPane3 = New Elegant.Ui.StatusBarPane()
      Me.Label2 = New Elegant.Ui.Label()
      Me.StatusBarControlsArea1 = New Elegant.Ui.StatusBarControlsArea()
      Me.StatusBarPane4 = New Elegant.Ui.StatusBarPane()
      Me.eui_cmdTastiera = New Elegant.Ui.Button()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_tpcDocumento = New Elegant.Ui.TabControl()
      Me.TabPage1 = New Elegant.Ui.TabPage()
      Me.TabPage2 = New Elegant.Ui.TabPage()
      Me.eui_cmdSalvaErrori = New Elegant.Ui.Button()
      Me.eui_cmdConvalida = New Elegant.Ui.Button()
      Me.eui_txtNote = New Elegant.Ui.TextBox()
      Me.TabPage3 = New Elegant.Ui.TabPage()
      Me.eui_cmdCopiaPercorso = New Elegant.Ui.Button()
      Me.TextBox1 = New Elegant.Ui.TextBox()
      Me.eui_cmdSalvaTestoXml = New Elegant.Ui.Button()
      Me.TabPage4 = New Elegant.Ui.TabPage()
      Me.eui_cmdSalvaAnteprimaHtml = New Elegant.Ui.Button()
      Me.eui_cmdApriCartella = New Elegant.Ui.Button()
      Me.eui_cmdEsporta = New Elegant.Ui.Button()
      Me.eui_cmdInvia = New Elegant.Ui.Button()
      Me.StatusBarPane5 = New Elegant.Ui.StatusBarPane()
      Me.eui_lblStatoDataDoc = New Elegant.Ui.Label()
      Me.StatusBarPane1 = New Elegant.Ui.StatusBarPane()
      Me.eui_lblStatoClienteDoc = New Elegant.Ui.Label()
      Me.StatusBar1.SuspendLayout()
      Me.StatusBarNotificationsArea1.SuspendLayout()
      Me.StatusBarPane2.SuspendLayout()
      Me.StatusBarPane3.SuspendLayout()
      Me.StatusBarControlsArea1.SuspendLayout()
      CType(Me.eui_tpcDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage2.SuspendLayout()
      Me.TabPage3.SuspendLayout()
      Me.TabPage4.SuspendLayout()
      Me.StatusBarPane5.SuspendLayout()
      Me.StatusBarPane1.SuspendLayout()
      Me.SuspendLayout()
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'StatusBar1
      '
      Me.StatusBar1.Controls.Add(Me.StatusBarNotificationsArea1)
      Me.StatusBar1.Controls.Add(Me.StatusBarControlsArea1)
      Me.StatusBar1.ControlsArea = Me.StatusBarControlsArea1
      Me.StatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.StatusBar1.Location = New System.Drawing.Point(0, 528)
      Me.StatusBar1.Name = "StatusBar1"
      Me.StatusBar1.NotificationsArea = Me.StatusBarNotificationsArea1
      Me.StatusBar1.Size = New System.Drawing.Size(902, 22)
      Me.StatusBar1.TabIndex = 4
      Me.StatusBar1.Text = "StatusBar1"
      '
      'StatusBarNotificationsArea1
      '
      Me.StatusBarNotificationsArea1.Controls.Add(Me.StatusBarPane2)
      Me.StatusBarNotificationsArea1.Controls.Add(Me.StatusBarPane3)
      Me.StatusBarNotificationsArea1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.StatusBarNotificationsArea1.Location = New System.Drawing.Point(0, 0)
      Me.StatusBarNotificationsArea1.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarNotificationsArea1.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarNotificationsArea1.Name = "StatusBarNotificationsArea1"
      Me.StatusBarNotificationsArea1.Size = New System.Drawing.Size(830, 22)
      Me.StatusBarNotificationsArea1.TabIndex = 1
      '
      'StatusBarPane2
      '
      Me.StatusBarPane2.Controls.Add(Me.Label1)
      Me.StatusBarPane2.Controls.Add(Me.LinkLabel2)
      Me.StatusBarPane2.Controls.Add(Me.LinkLabel1)
      Me.StatusBarPane2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.StatusBarPane2.Location = New System.Drawing.Point(0, 0)
      Me.StatusBarPane2.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane2.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane2.Name = "StatusBarPane2"
      Me.StatusBarPane2.ScreenTip.Text = "Numero documento"
      Me.StatusBarPane2.Size = New System.Drawing.Size(404, 22)
      Me.StatusBarPane2.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(5, 5)
      Me.Label1.Name = "Label1"
      Me.Label1.ScreenTip.Text = "Cliente intestatario"
      Me.Label1.Size = New System.Drawing.Size(114, 13)
      Me.Label1.TabIndex = 24
      Me.Label1.Text = "Per info e servizi gratuiti:"
      '
      'LinkLabel2
      '
      Me.LinkLabel2.ActiveLinkColor = System.Drawing.Color.White
      Me.LinkLabel2.AutoSize = True
      Me.LinkLabel2.BackColor = System.Drawing.Color.Transparent
      Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.LinkLabel2.Location = New System.Drawing.Point(125, 5)
      Me.LinkLabel2.Name = "LinkLabel2"
      Me.LinkLabel2.Size = New System.Drawing.Size(133, 13)
      Me.LinkLabel2.TabIndex = 25
      Me.LinkLabel2.TabStop = True
      Me.LinkLabel2.Text = "www.agenziaentrate.gov.it"
      Me.LinkLabel2.VisitedLinkColor = System.Drawing.Color.Magenta
      '
      'LinkLabel1
      '
      Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.White
      Me.LinkLabel1.AutoSize = True
      Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
      Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.LinkLabel1.Location = New System.Drawing.Point(264, 5)
      Me.LinkLabel1.Name = "LinkLabel1"
      Me.LinkLabel1.Size = New System.Drawing.Size(105, 13)
      Me.LinkLabel1.TabIndex = 26
      Me.LinkLabel1.TabStop = True
      Me.LinkLabel1.Text = "www.fatturapa.gov.it"
      Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.Magenta
      '
      'StatusBarPane3
      '
      Me.StatusBarPane3.Controls.Add(Me.Label2)
      Me.StatusBarPane3.Location = New System.Drawing.Point(404, 0)
      Me.StatusBarPane3.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane3.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane3.Name = "StatusBarPane3"
      Me.StatusBarPane3.Size = New System.Drawing.Size(303, 22)
      Me.StatusBarPane3.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(5, 5)
      Me.Label2.Name = "Label2"
      Me.Label2.ScreenTip.Text = "Numero documento"
      Me.Label2.Size = New System.Drawing.Size(263, 13)
      Me.Label2.TabIndex = 26
      Me.Label2.Text = "C:\Migg\Gim9\Archivi\Xml\IT00000000000_D9757.xml"
      '
      'StatusBarControlsArea1
      '
      Me.StatusBarControlsArea1.Controls.Add(Me.StatusBarPane4)
      Me.StatusBarControlsArea1.Dock = System.Windows.Forms.DockStyle.Right
      Me.StatusBarControlsArea1.Location = New System.Drawing.Point(830, 0)
      Me.StatusBarControlsArea1.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarControlsArea1.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarControlsArea1.Name = "StatusBarControlsArea1"
      Me.StatusBarControlsArea1.Size = New System.Drawing.Size(72, 22)
      Me.StatusBarControlsArea1.TabIndex = 0
      '
      'StatusBarPane4
      '
      Me.StatusBarPane4.Location = New System.Drawing.Point(0, 0)
      Me.StatusBarPane4.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane4.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane4.Name = "StatusBarPane4"
      Me.StatusBarPane4.Size = New System.Drawing.Size(20, 22)
      Me.StatusBarPane4.TabIndex = 0
      '
      'eui_cmdTastiera
      '
      Me.eui_cmdTastiera.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdTastiera.Id = "295ab16e-e7c5-4477-a8b5-fc8631e2896a"
      Me.eui_cmdTastiera.Location = New System.Drawing.Point(752, 430)
      Me.eui_cmdTastiera.Name = "eui_cmdTastiera"
      Me.eui_cmdTastiera.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdTastiera.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdTastiera.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdTastiera.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdTastiera.TabIndex = 14
      Me.eui_cmdTastiera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Id = "73a9f32c-e7b8-41a5-b071-7351d12b4ba9"
      Me.eui_cmdAnnulla.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(752, 356)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.ScreenTip.Caption = "Esci"
      Me.eui_cmdAnnulla.ScreenTip.Text = "Annula le modifiche e chiude il documento."
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdAnnulla.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdAnnulla.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdAnnulla.TabIndex = 13
      Me.eui_cmdAnnulla.Text = "Esci"
      Me.eui_cmdAnnulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_tpcDocumento
      '
      Me.eui_tpcDocumento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_tpcDocumento.EndScrollButtonVisible = True
      Me.eui_tpcDocumento.EqualTabHeight = True
      Me.eui_tpcDocumento.EqualTabWidth = True
      Me.eui_tpcDocumento.Location = New System.Drawing.Point(9, 9)
      Me.eui_tpcDocumento.Name = "eui_tpcDocumento"
      Me.eui_tpcDocumento.SelectedTabPage = Me.TabPage1
      Me.eui_tpcDocumento.Size = New System.Drawing.Size(730, 485)
      Me.eui_tpcDocumento.TabIndex = 15
      Me.eui_tpcDocumento.TabPages.AddRange(New Elegant.Ui.TabPage() {Me.TabPage1, Me.TabPage2, Me.TabPage3, Me.TabPage4})
      Me.eui_tpcDocumento.Text = " "
      '
      'TabPage1
      '
      Me.TabPage1.ActiveControl = Nothing
      Me.TabPage1.KeyTip = Nothing
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(728, 464)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Intestazione"
      '
      'TabPage2
      '
      Me.TabPage2.ActiveControl = Nothing
      Me.TabPage2.Controls.Add(Me.eui_cmdSalvaErrori)
      Me.TabPage2.Controls.Add(Me.eui_cmdConvalida)
      Me.TabPage2.Controls.Add(Me.eui_txtNote)
      Me.TabPage2.KeyTip = Nothing
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Size = New System.Drawing.Size(728, 464)
      Me.TabPage2.TabIndex = 1
      Me.TabPage2.Text = "Convalida"
      '
      'eui_cmdSalvaErrori
      '
      Me.eui_cmdSalvaErrori.Id = "b3876e90-9e2d-438a-ab42-9cb94349f33f"
      Me.eui_cmdSalvaErrori.Location = New System.Drawing.Point(607, 423)
      Me.eui_cmdSalvaErrori.Name = "eui_cmdSalvaErrori"
      Me.eui_cmdSalvaErrori.Size = New System.Drawing.Size(110, 32)
      Me.eui_cmdSalvaErrori.TabIndex = 3
      Me.eui_cmdSalvaErrori.Text = "Salva lista errori"
      '
      'eui_cmdConvalida
      '
      Me.eui_cmdConvalida.Id = "f06cd621-78bb-492f-aebb-74b0711187e1"
      Me.eui_cmdConvalida.Location = New System.Drawing.Point(486, 423)
      Me.eui_cmdConvalida.Name = "eui_cmdConvalida"
      Me.eui_cmdConvalida.Size = New System.Drawing.Size(110, 32)
      Me.eui_cmdConvalida.TabIndex = 2
      Me.eui_cmdConvalida.Text = "Convalida"
      '
      'eui_txtNote
      '
      Me.eui_txtNote.Id = "fbd1d89a-a47f-4e31-b0e7-81fc65da197c"
      Me.eui_txtNote.Location = New System.Drawing.Point(1, 0)
      Me.eui_txtNote.Multiline = True
      Me.eui_txtNote.Name = "eui_txtNote"
      Me.eui_txtNote.Size = New System.Drawing.Size(726, 412)
      Me.eui_txtNote.TabIndex = 1
      Me.eui_txtNote.TextEditorWidth = 720
      '
      'TabPage3
      '
      Me.TabPage3.ActiveControl = Nothing
      Me.TabPage3.Controls.Add(Me.eui_cmdCopiaPercorso)
      Me.TabPage3.Controls.Add(Me.TextBox1)
      Me.TabPage3.Controls.Add(Me.eui_cmdSalvaTestoXml)
      Me.TabPage3.KeyTip = Nothing
      Me.TabPage3.Name = "TabPage3"
      Me.TabPage3.Size = New System.Drawing.Size(728, 464)
      Me.TabPage3.TabIndex = 2
      Me.TabPage3.Text = "XML"
      '
      'eui_cmdCopiaPercorso
      '
      Me.eui_cmdCopiaPercorso.Id = "60ebbd95-62c4-4451-90f1-4270387cc16d"
      Me.eui_cmdCopiaPercorso.Location = New System.Drawing.Point(486, 423)
      Me.eui_cmdCopiaPercorso.Name = "eui_cmdCopiaPercorso"
      Me.eui_cmdCopiaPercorso.ScreenTip.Caption = "Copia percorso"
      Me.eui_cmdCopiaPercorso.ScreenTip.Text = "Copia il percorso del file XML negli appunti."
      Me.eui_cmdCopiaPercorso.Size = New System.Drawing.Size(110, 32)
      Me.eui_cmdCopiaPercorso.TabIndex = 7
      Me.eui_cmdCopiaPercorso.Text = "Copia percorso"
      '
      'TextBox1
      '
      Me.TextBox1.Id = "61ba143f-bd45-4a17-9e69-c0fc9db9d3a3"
      Me.TextBox1.Location = New System.Drawing.Point(1, 0)
      Me.TextBox1.Multiline = True
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(726, 412)
      Me.TextBox1.TabIndex = 6
      Me.TextBox1.TextEditorWidth = 720
      '
      'eui_cmdSalvaTestoXml
      '
      Me.eui_cmdSalvaTestoXml.Id = "396425fd-fa39-42d2-8af8-2039c1104cdd"
      Me.eui_cmdSalvaTestoXml.Location = New System.Drawing.Point(607, 423)
      Me.eui_cmdSalvaTestoXml.Name = "eui_cmdSalvaTestoXml"
      Me.eui_cmdSalvaTestoXml.ScreenTip.Caption = "Salva"
      Me.eui_cmdSalvaTestoXml.ScreenTip.Text = "Salva il codice XML in un file di testo TXT."
      Me.eui_cmdSalvaTestoXml.Size = New System.Drawing.Size(110, 32)
      Me.eui_cmdSalvaTestoXml.TabIndex = 5
      Me.eui_cmdSalvaTestoXml.Text = "Salva"
      '
      'TabPage4
      '
      Me.TabPage4.ActiveControl = Nothing
      Me.TabPage4.Controls.Add(Me.eui_cmdSalvaAnteprimaHtml)
      Me.TabPage4.KeyTip = Nothing
      Me.TabPage4.Name = "TabPage4"
      Me.TabPage4.Size = New System.Drawing.Size(728, 464)
      Me.TabPage4.TabIndex = 3
      Me.TabPage4.Text = "Anteprima"
      '
      'eui_cmdSalvaAnteprimaHtml
      '
      Me.eui_cmdSalvaAnteprimaHtml.Id = "bfe22173-aa8c-41f0-9da6-be644ae84a1e"
      Me.eui_cmdSalvaAnteprimaHtml.Location = New System.Drawing.Point(607, 423)
      Me.eui_cmdSalvaAnteprimaHtml.Name = "eui_cmdSalvaAnteprimaHtml"
      Me.eui_cmdSalvaAnteprimaHtml.ScreenTip.Caption = "Salva"
      Me.eui_cmdSalvaAnteprimaHtml.ScreenTip.Text = "Salva una copia visualizzabile della Fattura Elettronica XML in un file HTML."
      Me.eui_cmdSalvaAnteprimaHtml.Size = New System.Drawing.Size(110, 32)
      Me.eui_cmdSalvaAnteprimaHtml.TabIndex = 7
      Me.eui_cmdSalvaAnteprimaHtml.Text = "Salva"
      '
      'eui_cmdApriCartella
      '
      Me.eui_cmdApriCartella.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdApriCartella.Id = "26a292a3-ef05-45a1-8f74-0996002fd2fc"
      Me.eui_cmdApriCartella.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdApriCartella.Location = New System.Drawing.Point(752, 29)
      Me.eui_cmdApriCartella.Name = "eui_cmdApriCartella"
      Me.eui_cmdApriCartella.ScreenTip.Caption = "Anteprima"
      Me.eui_cmdApriCartella.ScreenTip.Text = "Salva e visualizza l'anteprima del documento."
      Me.eui_cmdApriCartella.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdApriCartella.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdAnteprima.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdApriCartella.TabIndex = 16
      Me.eui_cmdApriCartella.Text = "Apri cartella..."
      Me.eui_cmdApriCartella.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_cmdEsporta
      '
      Me.eui_cmdEsporta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdEsporta.Id = "5d8dd0e2-1657-41ae-af95-d93b67be2536"
      Me.eui_cmdEsporta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdEsporta.Location = New System.Drawing.Point(752, 279)
      Me.eui_cmdEsporta.Name = "eui_cmdEsporta"
      Me.eui_cmdEsporta.ScreenTip.Caption = "Salva"
      Me.eui_cmdEsporta.ScreenTip.Text = "Salva il documento."
      Me.eui_cmdEsporta.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdEsporta.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("Button1.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdEsporta.TabIndex = 17
      Me.eui_cmdEsporta.Text = "Esporta"
      Me.eui_cmdEsporta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_cmdInvia
      '
      Me.eui_cmdInvia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdInvia.Id = "e098d816-fac2-4c14-bb8e-ded39b6e9ceb"
      Me.eui_cmdInvia.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdInvia.Location = New System.Drawing.Point(752, 107)
      Me.eui_cmdInvia.Name = "eui_cmdInvia"
      Me.eui_cmdInvia.ScreenTip.Caption = "Anteprima"
      Me.eui_cmdInvia.ScreenTip.Text = "Salva e visualizza l'anteprima del documento."
      Me.eui_cmdInvia.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdInvia.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("Button8.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdInvia.TabIndex = 18
      Me.eui_cmdInvia.Text = "Invia"
      Me.eui_cmdInvia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'StatusBarPane5
      '
      Me.StatusBarPane5.Controls.Add(Me.eui_lblStatoDataDoc)
      Me.StatusBarPane5.Dock = System.Windows.Forms.DockStyle.Fill
      Me.StatusBarPane5.Location = New System.Drawing.Point(87, 0)
      Me.StatusBarPane5.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane5.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane5.Name = "StatusBarPane5"
      Me.StatusBarPane5.Size = New System.Drawing.Size(20, 22)
      Me.StatusBarPane5.TabIndex = 1
      '
      'eui_lblStatoDataDoc
      '
      Me.eui_lblStatoDataDoc.Location = New System.Drawing.Point(0, 4)
      Me.eui_lblStatoDataDoc.Name = "eui_lblStatoDataDoc"
      Me.eui_lblStatoDataDoc.ScreenTip.Text = "Data documento"
      Me.eui_lblStatoDataDoc.Size = New System.Drawing.Size(58, 13)
      Me.eui_lblStatoDataDoc.TabIndex = 0
      Me.eui_lblStatoDataDoc.Text = "15/08/2015"
      '
      'StatusBarPane1
      '
      Me.StatusBarPane1.Controls.Add(Me.eui_lblStatoClienteDoc)
      Me.StatusBarPane1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.StatusBarPane1.Location = New System.Drawing.Point(185, 0)
      Me.StatusBarPane1.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane1.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane1.Name = "StatusBarPane1"
      Me.StatusBarPane1.Size = New System.Drawing.Size(20, 22)
      Me.StatusBarPane1.TabIndex = 2
      '
      'eui_lblStatoClienteDoc
      '
      Me.eui_lblStatoClienteDoc.Location = New System.Drawing.Point(0, 4)
      Me.eui_lblStatoClienteDoc.Name = "eui_lblStatoClienteDoc"
      Me.eui_lblStatoClienteDoc.ScreenTip.Text = "Cliente intestatario"
      Me.eui_lblStatoClienteDoc.Size = New System.Drawing.Size(89, 13)
      Me.eui_lblStatoClienteDoc.TabIndex = 0
      Me.eui_lblStatoClienteDoc.Text = "Luigi Montana Spa"
      '
      'FatturaElettronica
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(902, 550)
      Me.Controls.Add(Me.eui_cmdInvia)
      Me.Controls.Add(Me.eui_cmdEsporta)
      Me.Controls.Add(Me.eui_cmdApriCartella)
      Me.Controls.Add(Me.eui_tpcDocumento)
      Me.Controls.Add(Me.eui_cmdTastiera)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.StatusBar1)
      Me.Name = "FatturaElettronica"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Fattura Elettronica"
      Me.StatusBar1.ResumeLayout(False)
      Me.StatusBar1.PerformLayout()
      Me.StatusBarNotificationsArea1.ResumeLayout(False)
      Me.StatusBarNotificationsArea1.PerformLayout()
      Me.StatusBarPane2.ResumeLayout(False)
      Me.StatusBarPane2.PerformLayout()
      Me.StatusBarPane3.ResumeLayout(False)
      Me.StatusBarPane3.PerformLayout()
      Me.StatusBarControlsArea1.ResumeLayout(False)
      Me.StatusBarControlsArea1.PerformLayout()
      CType(Me.eui_tpcDocumento, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage2.ResumeLayout(False)
      Me.TabPage2.PerformLayout()
      Me.TabPage3.ResumeLayout(False)
      Me.TabPage3.PerformLayout()
      Me.TabPage4.ResumeLayout(False)
      Me.StatusBarPane5.ResumeLayout(False)
      Me.StatusBarPane5.PerformLayout()
      Me.StatusBarPane1.ResumeLayout(False)
      Me.StatusBarPane1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents StatusBar1 As Elegant.Ui.StatusBar
   Friend WithEvents StatusBarNotificationsArea1 As Elegant.Ui.StatusBarNotificationsArea
   Friend WithEvents StatusBarPane2 As Elegant.Ui.StatusBarPane
   Friend WithEvents StatusBarControlsArea1 As Elegant.Ui.StatusBarControlsArea
   Friend WithEvents eui_cmdTastiera As Elegant.Ui.Button
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_tpcDocumento As Elegant.Ui.TabControl
   Friend WithEvents TabPage1 As Elegant.Ui.TabPage
   Friend WithEvents TabPage2 As Elegant.Ui.TabPage
   Friend WithEvents TabPage3 As Elegant.Ui.TabPage
   Friend WithEvents TabPage4 As Elegant.Ui.TabPage
   Friend WithEvents eui_cmdEsporta As Elegant.Ui.Button
   Friend WithEvents eui_cmdApriCartella As Elegant.Ui.Button
   Friend WithEvents TextBox1 As Elegant.Ui.TextBox
   Friend WithEvents eui_cmdSalvaTestoXml As Elegant.Ui.Button
   Friend WithEvents eui_cmdSalvaErrori As Elegant.Ui.Button
   Friend WithEvents eui_cmdConvalida As Elegant.Ui.Button
   Friend WithEvents eui_txtNote As Elegant.Ui.TextBox
   Friend WithEvents eui_cmdSalvaAnteprimaHtml As Elegant.Ui.Button
   Friend WithEvents eui_cmdCopiaPercorso As Elegant.Ui.Button
   Friend WithEvents eui_cmdInvia As Elegant.Ui.Button
   Friend WithEvents StatusBarPane5 As Elegant.Ui.StatusBarPane
   Friend WithEvents eui_lblStatoDataDoc As Elegant.Ui.Label
   Friend WithEvents StatusBarPane1 As Elegant.Ui.StatusBarPane
   Friend WithEvents eui_lblStatoClienteDoc As Elegant.Ui.Label
   Friend WithEvents Label1 As Elegant.Ui.Label
   Friend WithEvents LinkLabel2 As LinkLabel
   Friend WithEvents LinkLabel1 As LinkLabel
   Friend WithEvents StatusBarPane3 As Elegant.Ui.StatusBarPane
   Friend WithEvents Label2 As Elegant.Ui.Label
   Friend WithEvents StatusBarPane4 As Elegant.Ui.StatusBarPane
End Class
