#Region " DATI FILE.VB "
' ***************************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       29/10/2018
' Data ultima modifica: 29/10/2018
' Descrizione:          Form per la compilazione della Fattura elettronica con generazione file XML.
' Note:
'
' Elenco Attivita:
'
' ***************************************************************************************************
#End Region

Imports FatturaElettronica
Imports FatturaElettronica.Validators
Imports FatturaElettronica.Impostazioni
Imports System.Xml

Public Class frmFatturaElettronica

   Private Sub FatturaElettronica_Load(sender As Object, e As EventArgs) Handles Me.Load
      Try
         ImpostaIcona(Me)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub FatturaElettronica_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      Try
         ' Distrugge l'oggetto e libera le risorse.
         g_frmFatturaElettronica.Dispose()
         g_frmFatturaElettronica = Nothing

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdEsporta_Click(sender As Object, e As EventArgs) Handles eui_cmdEsporta.Click
      Try
         Dim fatturaXlm As Fattura = Fattura.CreateInstance(Instance.PubblicaAmministrazione)

         Dim settings As New XmlReaderSettings()
         settings.IgnoreWhitespace = True
         settings.IgnoreComments = True

         ' Modifica proprietà Header.
         fatturaXlm.Header.CedentePrestatore.Sede.Indirizzo = "Via Dolcedo, 121"

         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione = "Bianchi Srl"

         Dim settingsW As New XmlWriterSettings()
         settingsW.Indent = True

         ' Serializzazione XML
         Using writer As XmlWriter = XmlWriter.Create("Documenti\IT01234567890_FPA01.xml", settingsW)
            fatturaXlm.WriteXml(writer)
         End Using

         '' Lettura da file XML
         'Using reader As XmlReader = XmlReader.Create("IT01234567890_FPA02.xml", settings)
         '   fatturaXlm.ReadXml(reader)
         'End Using

         'For Each doc As FatturaElettronicaBody.Body In fatturaXlm.Body
         '   Me.Text = doc.DatiGenerali.DatiGeneraliDocumento.Numero & " - " & doc.DatiGenerali.DatiGeneraliDocumento.Data
         'Next

         '' Convalida del documento.
         'Dim validator As New FatturaValidator
         'Dim risultato As FluentValidation.Results.ValidationResult = validator.Validate(fatturaXlm)
         'Me.Text = risultato.IsValid

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub
End Class