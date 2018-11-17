#Region " DATI FILE.VB "
' ***************************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       29/10/2018
' Data ultima modifica: 17/11/2018
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
Imports System.IO

Public Class frmFatturaElettronica

   Private CConvalida As New ConvalidaKeyPress
   Private nomeDirectory As String = Application.StartupPath & "\" & CARTELLA_FATTURE_ELETTRONICHE & "\" & Today.Year.ToString

   Private Sub EsempioFatt()
      Try
         'Dim fatturaXlm As Fattura = Fattura.CreateInstance(Instance.PubblicaAmministrazione)

         'Dim settings As New XmlReaderSettings()
         'settings.IgnoreWhitespace = True
         'settings.IgnoreComments = True

         '' Modifica proprietà Header.
         'fatturaXlm.Header.CedentePrestatore.Sede.Indirizzo = "Via Dolcedo, 121"

         'fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione = "Bianchi Srl"

         'Dim settingsW As New XmlWriterSettings()
         'settingsW.Indent = True

         '' Serializzazione XML
         'Using writer As XmlWriter = XmlWriter.Create("Documenti\IT01234567890_FPA01.xml", settingsW)
         '   fatturaXlm.WriteXml(writer)
         'End Using

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

   Private Function ConvalidaFileXML(ByVal nomefile As String) As Boolean
      Try
         ' Formato di trasmissione.
         Dim fatturaXlm As Fattura
         Select Case eui_cmbFormatoTrasmissione.SelectedIndex
            Case 0
               fatturaXlm = Fattura.CreateInstance(Instance.PubblicaAmministrazione)
            Case 1
               fatturaXlm = Fattura.CreateInstance(Instance.Privati)
         End Select

         Dim settings As New XmlReaderSettings()
         settings.IgnoreWhitespace = True
         settings.IgnoreComments = True

         ' Lettura da file XML
         Using reader As XmlReader = XmlReader.Create(nomefile, settings)
            fatturaXlm.ReadXml(reader)
         End Using

         ' Convalida del documento.
         Dim validator As New FatturaValidator
         Dim risultato As FluentValidation.Results.ValidationResult = validator.Validate(fatturaXlm)

         If risultato.IsValid = True Then
            eui_txtConvalida.Text = "Documento corretto!"
         Else
            Dim i As Integer
            For Each errore As FluentValidation.Results.ValidationFailure In risultato.Errors
               eui_txtConvalida.Text = eui_txtConvalida.Text & errore.PropertyName & " " & errore.ErrorMessage & " " & errore.ErrorCode & vbCrLf
            Next
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function GeneraFileXML(ByVal nomefile As String) As Boolean
      Try

#Region "FORMATO DI TRASMISSIONE "

         ' Formato di trasmissione.
         Dim fatturaXlm As Fattura
         Select Case eui_cmbFormatoTrasmissione.SelectedIndex
            Case 0
               fatturaXlm = Fattura.CreateInstance(Instance.PubblicaAmministrazione)
            Case 1
               fatturaXlm = Fattura.CreateInstance(Instance.Privati)
         End Select

#End Region

#Region "FATTURA ELETTRONICA HEADER - OBBLIGATORIO "

#Region "DATI TRASMISSIONE - OBBLIGATORIO "
         ' OBBLIGATORIO - Sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         fatturaXlm.Header.DatiTrasmissione.IdTrasmittente.IdPaese = eui_cmbTrasmittenteIdPaese.Text.Substring(0, 2)

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 28 caratteri.
         fatturaXlm.Header.DatiTrasmissione.IdTrasmittente.IdCodice = eui_txtTrasmittenteIdCodice.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 10 caratteri.
         fatturaXlm.Header.DatiTrasmissione.ProgressivoInvio = eui_txtProgressivoInvio.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza di 5 caratteri; i valori ammessi sono i seguenti: 
         ' FPR12 Formato di Trasmissione fattura verso privati.
         ' FPA12 Formato di Trasmissione fattura pubblica amministrazione.
         fatturaXlm.Header.DatiTrasmissione.FormatoTrasmissione = eui_cmbFormatoTrasmissione.Text

         ' DA_FARE: Verificare!
         ' OBBLIGATORIO - Formato alfanumerico; lunghezza di 7 caratteri. Se esiste la PEC inserire 0000000.
         fatturaXlm.Header.DatiTrasmissione.CodiceDestinatario = eui_txtCodiceDestinatario.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 5 a 12 caratteri.
         fatturaXlm.Header.DatiTrasmissione.ContattiTrasmittente.Telefono = eui_txtTrasmittenteTelefono.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 7 a 256 caratteri.
         fatturaXlm.Header.DatiTrasmissione.ContattiTrasmittente.Email = eui_txtTrasmittenteEmail.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 7 a 256 caratteri.
         fatturaXlm.Header.DatiTrasmissione.PECDestinatario = eui_txtTrasmittentePECDestinatario.Text
#End Region

#Region "CEDENTE PRESTATORE - OBBLIGATORIO "
         ' OBBLIGATORIO - Sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdPaese = eui_cmbCpIdPaese.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 28 caratteri.
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdCodice = eui_txtCpIdCodice.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza compresa tra 11 e 16 caratteri.
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.CodiceFiscale = eui_txtCpCodiceFiscale.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 80 caratteri. Da valorizzare in alternativa ai campi Nome e Cognome seguenti.
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione = eui_txtCpDenominazione.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Cognome ed in alternativa al campo Denominazione.
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Nome = eui_txtCpNome.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Nome ed in alternativa al campo Denominazione.
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Cognome = eui_txtCpCognome.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 2 a 10 caratteri.
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Titolo = eui_txtCpTitolo.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 13 a 17 caratteri.
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.CodEORI = eui_txtCpCodiceEORI.Text

         ' FACOLTATIVO - Alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.AlboProfessionale = eui_txtCpAlboProfessionale.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza di 2 caratteri.
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.ProvinciaAlbo = eui_cmbCpProvinciaAlbo.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.NumeroIscrizioneAlbo = eui_txtCpNumeroIscrizioneAlbo.Text

         ' FACOLTATIVO - La data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.DataIscrizioneAlbo = eui_dtpCpDataIscrizioneAlbo.Value.ToString

         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 4 caratteri; i valori ammessi sono i seguenti:
         ' RF01 Ordinario;
         ' RF02 Contribuenti minimi (art. 1, c.96-117, L. 244/2007);
         ' RF04 Agricoltura e attività connesse e pesca (artt. 34 e 34-bis, D.P.R. 633/1972);
         ' RF05 Vendita sali e tabacchi (art. 74, c.1, D.P.R. 633/1972);
         ' RF06 Commercio dei fiammiferi (art. 74, c.1, D.P.R. 633/1972);
         ' RF07 Editoria(art. 74, c.1, D.P.R. 633/1972);
         ' RF08 Gestione di servizi di telefonia pubblica (art. 74, c.1, D.P.R. 633/1972);
         ' RF09 Rivendita di documenti di trasporto pubblico e di sosta (art. 74, c.1, D.P.R. 633/1972);
         ' RF10 Intrattenimenti, giochi e altre attività di cui alla tariffa allegata al D.P.R. n. 640/72 (art. 74, c.6, D.P.R. 633/1972);
         ' RF11 Agenzie di viaggi e turismo (art. 74-ter, D.P.R. 633/1972);
         ' RF12 Agriturismo(art. 5, c.2, L. 413/1991);
         ' RF13 Vendite a domicilio (art. 25-bis, c.6, D.P.R. 600/1973);
         ' RF14 Rivendita di beni usati, di oggetti d'arte, d’antiquariato o da collezione (art. 36, D.L. 41/1995);
         ' RF15 Agenzie di vendite all'asta di oggetti d’arte, antiquariato o da collezione (art. 40-bis, D.L. 41/1995);
         ' RF16 IVA per cassa P.A. (art. 6, c.5, D.P.R. 633/1972);
         ' RF17 IVA per cassa (art. 32-bis, D.L. 83/2012);
         ' RF18 Altro;
         ' RF19 Forfettario(art.1, c. 54-89, L. 190/2014)
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.RegimeFiscale = eui_cmbCpRegimeFiscale.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Header.CedentePrestatore.Sede.Indirizzo = eui_txtCpSedeIndirizzo.Text

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 8 caratteri.
         fatturaXlm.Header.CedentePrestatore.Sede.NumeroCivico = eui_txtCpSedeNumeroCivico.Text

         ' OBBLIGATORIO - formato numerico; lunghezza di 5 caratteri.
         fatturaXlm.Header.CedentePrestatore.Sede.CAP = eui_txtCpSedeCAP.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Header.CedentePrestatore.Sede.Comune = eui_txtCpSedeComune.Text

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri.
         fatturaXlm.Header.CedentePrestatore.Sede.Provincia = eui_cmbCpSedeProvincia.Text

         ' OBBLIGATORIO - sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         fatturaXlm.Header.CedentePrestatore.Sede.Nazione = eui_cmbCpSedeNazione.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.Indirizzo = eui_txtCpStabileOrgIndirizzo.Text

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 8 caratteri.
         fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.NumeroCivico = eui_txtCpStabileOrgNumeroCivico.Text

         ' OBBLIGATORIO - formato numerico; lunghezza di 5 caratteri.
         fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.CAP = eui_txtCpStabileOrgCAP.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.Comune = eui_txtCpStabileOrgComune.Text

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri.
         fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.Provincia = eui_cmbCpStabileOrgProvincia.Text

         ' OBBLIGATORIO - sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.Nazione = eui_cmbCpStabileOrgNazione.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 2 caratteri.
         fatturaXlm.Header.CedentePrestatore.IscrizioneREA.Ufficio = eui_cmbCpUfficioREA.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Header.CedentePrestatore.IscrizioneREA.NumeroREA = eui_txtCpNumeroREA.Text

         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Header.CedentePrestatore.IscrizioneREA.CapitaleSociale = Convert.ToDecimal(eui_txtCpCapitaleSocialeREA.Text)

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
         ' SU la società è a socio unico.
         ' SM la società NON è a socio unico.
         fatturaXlm.Header.CedentePrestatore.IscrizioneREA.SocioUnico = eui_cmbCpSocioUnicoREA.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
         ' LS la società è in stato di liquidazione.
         ' LN la società NON è in stato di liquidazione.
         fatturaXlm.Header.CedentePrestatore.IscrizioneREA.StatoLiquidazione = eui_cmbCpStatoLiquidazioneREA.Text

         ' FACOLTATIVO - formato alfanumerico; lunghezza che va da 5 a 12 caratteri.
         fatturaXlm.Header.CedentePrestatore.Contatti.Telefono = eui_txtCpTelefono.Text

         ' FACOLTATIVO - formato alfanumerico; lunghezza che va da 5 a 12 caratteri.
         fatturaXlm.Header.CedentePrestatore.Contatti.Fax = eui_txtCpFax.Text

         ' FACOLTATIVO - formato alfanumerico; lunghezza che va da 7 a 256 caratteri.
         fatturaXlm.Header.CedentePrestatore.Contatti.Email = eui_txtCpEmail.Text

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Header.CedentePrestatore.RiferimentoAmministrazione = eui_txtCpRifAmministrazione.Text
#End Region

#Region "RAPPRESENTANTE FISCALE - FACOLTATIVO "
         ' OBBLIGATORIO - Sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         fatturaXlm.Header.Rappresentante.DatiAnagrafici.IdFiscaleIVA.IdPaese = eui_cmbRfCpIdPaese.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 28 caratteri.
         fatturaXlm.Header.Rappresentante.DatiAnagrafici.IdFiscaleIVA.IdCodice = eui_txtRfCpIdCodice.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza compresa tra 11 e 16 caratteri.
         fatturaXlm.Header.Rappresentante.DatiAnagrafici.CodiceFiscale = eui_txtRfCpCodiceFiscale.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 80 caratteri. Da valorizzare in alternativa ai campi Nome e Cognome seguenti.
         fatturaXlm.Header.Rappresentante.DatiAnagrafici.Anagrafica.Denominazione = eui_txtRfCpDenominazione.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Cognome ed in alternativa al campo Denominazione.
         fatturaXlm.Header.Rappresentante.DatiAnagrafici.Anagrafica.Nome = eui_txtRfCpNome.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Nome ed in alternativa al campo Denominazione.
         fatturaXlm.Header.Rappresentante.DatiAnagrafici.Anagrafica.Cognome = eui_txtRfCpCognome.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 2 a 10 caratteri.
         fatturaXlm.Header.Rappresentante.DatiAnagrafici.Anagrafica.Titolo = eui_txtRfCpTitolo.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 13 a 17 caratteri.
         fatturaXlm.Header.Rappresentante.DatiAnagrafici.Anagrafica.CodEORI = eui_txtRfCpCodiceEORI.Text
#End Region

#Region "CESSIONARIO COMMITTENTE - OBBLIGATORIO "
         ' OBBLIGATORIO - Sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdPaese = eui_cmbCcIdPaese.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 28 caratteri.
         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice = eui_txtCcIdCodice.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza compresa tra 11 e 16 caratteri.
         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.CodiceFiscale = eui_txtCcCodiceFiscale.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 80 caratteri. Da valorizzare in alternativa ai campi Nome e Cognome seguenti.
         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.Anagrafica.Denominazione = eui_txtCcDenominazione.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Cognome ed in alternativa al campo Denominazione.
         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.Anagrafica.Nome = eui_txtCcNome.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Nome ed in alternativa al campo Denominazione.
         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.Anagrafica.Cognome = eui_txtCcCognome.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 2 a 10 caratteri.
         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.Anagrafica.Titolo = eui_txtCcTitolo.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 13 a 17 caratteri.
         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.Anagrafica.CodEORI = eui_txtCcCodiceEORI.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Header.CessionarioCommittente.Sede.Indirizzo = eui_txtCcSedeIndirizzo.Text

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 8 caratteri.
         fatturaXlm.Header.CessionarioCommittente.Sede.NumeroCivico = eui_txtCcSedeNumeroCivico.Text

         ' OBBLIGATORIO - formato numerico; lunghezza di 5 caratteri.
         fatturaXlm.Header.CessionarioCommittente.Sede.CAP = eui_txtCcSedeCAP.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Header.CessionarioCommittente.Sede.Comune = eui_txtCcSedeComune.Text

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri.
         fatturaXlm.Header.CessionarioCommittente.Sede.Provincia = eui_cmbCcSedeProvincia.Text

         ' OBBLIGATORIO - sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         fatturaXlm.Header.CessionarioCommittente.Sede.Nazione = eui_cmbCcSedeNazione.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.Indirizzo = eui_txtCcStabileOrgIndirizzo.Text

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 8 caratteri.
         fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.NumeroCivico = eui_txtCcStabileOrgNumeroCivico.Text

         ' OBBLIGATORIO - formato numerico; lunghezza di 5 caratteri.
         fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.CAP = eui_txtCcStabileOrgCAP.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.Comune = eui_txtCcStabileOrgComune.Text

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri.
         fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.Provincia = eui_cmbCcStabileOrgProvincia.Text

         ' OBBLIGATORIO - sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.Nazione = eui_cmbCcStabileOrgNazione.Text

         ' OBBLIGATORIO - Sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         fatturaXlm.Header.CessionarioCommittente.RappresentanteFiscale.IdFiscaleIVA.IdPaese = eui_cmbCcRfIdPaese.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 28 caratteri.
         fatturaXlm.Header.CessionarioCommittente.RappresentanteFiscale.IdFiscaleIVA.IdCodice = eui_txtCcRfIdCodice.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 80 caratteri. Da valorizzare in alternativa ai campi Nome e Cognome seguenti.
         fatturaXlm.Header.CessionarioCommittente.RappresentanteFiscale.Denominazione = eui_txtCcRfDenominazione.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Cognome ed in alternativa al campo Denominazione.
         fatturaXlm.Header.CessionarioCommittente.RappresentanteFiscale.Nome = eui_txtCcRfNome.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Nome ed in alternativa al campo Denominazione.
         fatturaXlm.Header.CessionarioCommittente.RappresentanteFiscale.Cognome = eui_txtCcRfCognome.Text
#End Region

#Region "TERZO INTERMEDIARIO O SOGGETTO EMITTENTE - FACOLTATIVO "
         ' OBBLIGATORIO - Sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.IdFiscaleIVA.IdPaese = eui_cmbTiSeIdPaese.Text

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 28 caratteri.
         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.IdFiscaleIVA.IdCodice = eui_txtTiSeIdCodice.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza compresa tra 11 e 16 caratteri.
         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.CodiceFiscale = eui_txtTiSeCodiceFiscale.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 80 caratteri. Da valorizzare in alternativa ai campi Nome e Cognome seguenti.
         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.Anagrafica.Denominazione = eui_txtTiSeDenominazione.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Cognome ed in alternativa al campo Denominazione.
         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.Anagrafica.Nome = eui_txtTiSeNome.Text

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Nome ed in alternativa al campo Denominazione.
         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.Anagrafica.Cognome = eui_txtTiSeCognome.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 2 a 10 caratteri.
         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.Anagrafica.Titolo = eui_txtTiSeTitolo.Text

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 13 a 17 caratteri.
         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.Anagrafica.CodEORI = eui_txtTiSeCodiceEORI.Text
#End Region

#Region "SOGGETTO EMITTENTE - FACOLTATIVO "
         ' FACOLTATIVO -  - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
         ' CC cessionario / committente.
         ' TZ soggetto terzo.
         fatturaXlm.Header.SoggettoEmittente = eui_cmbSoggettoEmittente.Text
#End Region

#End Region

#Region "FATTURA ELETTRONICA BODY - OBBLIGATORIO "

         Dim fattBody As New FatturaElettronicaBody.Body
         fatturaXlm.Body.Add(fattBody)

#Region "DATI GENERALI - OBBLIGATORIO "
         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 4 caratteri; i valori ammessi sono i seguenti:
         ' TD01 Fattura
         ' TD02 Acconto / Anticipo su fattura
         ' TD03 Acconto / Anticipo su parcella
         ' TD04 Nota di Credito
         ' TD05 Nota di Debito
         ' TD06 Parcella
         ' TD20 Autofattura
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.TipoDocumento = "TD01"

         ' OBBLIGATORIO - questo campo deve essere espresso secondo lo standard ISO 4217 alpha-3:2001 (es.: EUR, USD, GBP, CZK………).
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Divisa = ""

         ' OBBLIGATORIO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Data = Today.Date

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Numero = "1"

         ' FACOLTATIVO - OBBLIGATORIO - formato alfanumerico; lunghezza di 4 caratteri; i valori ammessi sono i seguenti:
         ' RT01 Ritenuta persone fisiche
         ' RT02 Ritenuta persone giuridiche
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.TipoRitenuta = ""

         ' FACOLTATIVO - OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.ImportoRitenuta = 0

         ' FACOLTATIVO - OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 6 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.AliquotaRitenuta = 0

         ' FACOLTATIVO - OBBLIGATORIO - formato alfanumerico; lunghezza di massimo 2 caratteri; i valori ammessi sono quelli del 770S consultabili alla pagina delle istruzioni di compilazione del modello.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.CausalePagamento = ""

         ' FACOLTATIVO - OBBLIGATORIO - formato alfanumerico, lunghezza di 2 caratteri; il valore ammesso è SI bollo assolto ai sensi del decreto MEF 14 giugno 2014.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiBollo.BolloVirtuale = ""

         ' FACOLTATIVO - OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiBollo.ImportoBollo = 0

         ' FACOLTATIVO - 
         Dim datiCassaPrevidenziale As New FatturaElettronicaBody.DatiGenerali.DatiCassaPrevidenziale
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Add(datiCassaPrevidenziale)

         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 4 caratteri; i valori ammessi sono i seguenti:
         ' TC01 Cassa Nazionale Previdenza e Assistenza Avvocati e Procuratori Legali
         ' TC02 Cassa Previdenza Dottori Commercialisti
         ' TC03 Cassa Previdenza e Assistenza Geometri
         ' TC04 Cassa Nazionale Previdenza e Assistenza Ingegneri e Architetti Liberi Professionisti
         ' TC05 Cassa Nazionale del Notariato
         ' TC06 Cassa Nazionale Previdenza e Assistenza Ragionieri e Periti Commerciali
         ' TC07 Ente Nazionale Assistenza Agenti e Rappresentanti di Commercio (ENASARCO)
         ' TC08 Ente Nazionale Previdenza e Assistenza Consulenti del Lavoro (ENPACL)
         ' TC09 Ente Nazionale Previdenza e Assistenza Medici (ENPAM)
         ' TC10 Ente Nazionale Previdenza e Assistenza Farmacisti (ENPAF)
         ' TC11 Ente Nazionale Previdenza e Assistenza Veterinari (ENPAV)
         ' TC12 Ente Nazionale Previdenza e Assistenza Impiegati dell'Agricoltura (ENPAIA)
         ' TC13 Fondo Previdenza Impiegati Imprese di Spedizione e Agenzie Marittime
         ' TC14 Istituto Nazionale Previdenza Giornalisti Italiani (INPGI)
         ' TC15 Opera Nazionale Assistenza Orfani Sanitari Italiani (ONAOSI)
         ' TC16 Cassa Autonoma Assistenza Integrativa Giornalisti Italiani (CASAGIT)
         ' TC17 Ente Previdenza Periti Industriali e Periti Industriali Laureati (EPPI)
         ' TC18 Ente Previdenza e Assistenza Pluricategoriale (EPAP)
         ' TC19 Ente Nazionale Previdenza e Assistenza Biologi (ENPAB)
         ' TC20 Ente Nazionale Previdenza e Assistenza Professione Infermieristica (ENPAPI)
         ' TC21 Ente Nazionale Previdenza e Assistenza Psicologi (ENPAP)
         ' TC22 INPS
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).TipoCassa = ""

         '  OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 6 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).AlCassa = 0

         ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).ImportoContributoCassa = 0

         ' FACOLTATIVO - formato numerico nel quale i decinali vanno separati dall’intero con il carattere ‘.’ (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).ImponibileCassa = 0

         ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 6 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).AliquotaIVA = 0

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; il valore ammesso è: SI contributo cassa soggetto a ritenuta.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).Ritenuta = ""

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
         ' N1 escluse ex art.15
         ' N2 non soggette
         ' N3 non imponibili
         ' N4 esenti
         ' N5 regime del margine / IVA non esposta in fattura
         ' N6 inversione contabile (per le operazioni in reverse charge ovvero nei casi di autofatturazione per acquisti extra UE di servizi ovvero per importazioni di beni nei soli casi previsti)
         ' N7 IVA assolta In altro stato UE (vendite a distanza ex art. 40 commi 3 e 4 e art. 41 comma 1 lett. b, DL 331/93; prestazione di servizi di telecomunicazioni, tele - radiodiffusione ed elettronici ex art. 7-sexies lett. f, g, DPR 633/72 e art. 74-sexies, DPR 633/72)
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).Natura = ""

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).RiferimentoAmministrazione = ""

         ' FACOLTATIVO
         Dim scontoMaggiorazione As New Common.ScontoMaggiorazione
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.ScontoMaggiorazione.Add(scontoMaggiorazione)

         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
         ' SC sconto
         ' MG maggiorazione
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.ScontoMaggiorazione.Item(0).Tipo = ""

         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall’intero con il carattere ‘.’ (punto). La sua lunghezza va da 4 a 6 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.ScontoMaggiorazione.Item(0).Percentuale = 0

         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall’intero con il carattere ‘.’ (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.ScontoMaggiorazione.Item(0).Importo = 0

         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.ImportoTotaleDocumento = 0

         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Arrotondamento = 0

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 200 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Causale.Add("")

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; il valore ammesso è:
         ' SI documento emesso secondo modalità e termini stabiliti con DM ai sensi del'’art. 73 del DPR 633/72.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Art73 = ""

         ' FACOLTATIVO
         Dim datiOrdineAcquisto As New FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Add(datiOrdineAcquisto)

         ' FACOLTATIVO - formato numerico; lunghezza massima di 4 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(0).RiferimentoNumeroLinea.Add(0)
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(0).IdDocumento = ""
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(0).Data = Today.Date
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(0).NumItem = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(0).CodiceCommessaConvenzione = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(0).CodiceCUP = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(0).CodiceCIG = ""

         ' FACOLTATIVO
         Dim datiContratto As New FatturaElettronicaBody.DatiGenerali.DatiContratto
         fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Add(datiContratto)

         ' FACOLTATIVO - formato numerico; lunghezza massima di 4 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Item(0).RiferimentoNumeroLinea.Add(0)
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Item(0).IdDocumento = ""
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Item(0).Data = Today.Date
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Item(0).NumItem = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Item(0).CodiceCommessaConvenzione = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Item(0).CodiceCUP = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Item(0).CodiceCIG = ""

         ' FACOLTATIVO
         Dim datiConvenzione As New FatturaElettronicaBody.DatiGenerali.DatiConvenzione
         fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Add(datiConvenzione)

         ' FACOLTATIVO - formato numerico; lunghezza massima di 4 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Item(0).RiferimentoNumeroLinea.Add(0)
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Item(0).IdDocumento = ""
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Item(0).Data = Today.Date
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Item(0).NumItem = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Item(0).CodiceCommessaConvenzione = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Item(0).CodiceCUP = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Item(0).CodiceCIG = ""

         ' FACOLTATIVO
         Dim datiRicezione As New FatturaElettronicaBody.DatiGenerali.DatiRicezione
         fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Add(datiRicezione)

         ' FACOLTATIVO - formato numerico; lunghezza massima di 4 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Item(0).RiferimentoNumeroLinea.Add(0)
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Item(0).IdDocumento = ""
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Item(0).Data = Today.Date
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Item(0).NumItem = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Item(0).CodiceCommessaConvenzione = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Item(0).CodiceCUP = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Item(0).CodiceCIG = ""

         ' FACOLTATIVO
         Dim datiFattureCollegate As New FatturaElettronicaBody.DatiGenerali.DatiFattureCollegate
         fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Add(datiFattureCollegate)

         ' FACOLTATIVO - formato numerico; lunghezza massima di 4 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Item(0).RiferimentoNumeroLinea.Add(0)
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Item(0).IdDocumento = ""
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Item(0).Data = Today.Date
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Item(0).NumItem = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Item(0).CodiceCommessaConvenzione = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Item(0).CodiceCUP = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Item(0).CodiceCIG = ""

         ' FACOLTATIVO
         Dim datiSAL As New FatturaElettronicaBody.DatiGenerali.DatiSAL
         fatturaXlm.Body.Item(0).DatiGenerali.DatiSAL.Add(datiSAL)

         ' OBBLIGATORIO - formato numerico; lunghezza massima di 3 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiSAL.Item(0).RiferimentoFase = 0

         ' FACOLTATIVO
         Dim datiDDT As New FatturaElettronicaBody.DatiGenerali.DatiDDT
         fatturaXlm.Body.Item(0).DatiGenerali.DatiDDT.Add(datiDDT)

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiDDT.Item(0).NumeroDDT = ""
         ' OBBLIGATORIO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiDDT.Item(0).DataDDT = Today.Date
         ' FACOLTATIVO - formato numerico; lunghezza massima di 4 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiDDT.Item(0).RiferimentoNumeroLinea.Add(0)

         ' FACOLTATIVO
         ' OBBLIGATORIO - Sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.IdFiscaleIVA.IdPaese = ""
         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 28 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.IdFiscaleIVA.IdCodice = ""
         ' FACOLTATIVO - Formato alfanumerico; lunghezza compresa tra 11 e 16 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.CodiceFiscale = ""
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 80 caratteri. Da valorizzare in alternativa ai campi Nome e Cognome seguenti.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.Denominazione = ""
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Cognome ed in alternativa al campo Denominazione.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.Nome = ""
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Nome ed in alternativa al campo Denominazione.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.Cognome = ""
         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 2 a 10 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.Titolo = ""
         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 13 a 17 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.CodEORI = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.NumeroLicenzaGuida = ""

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 80 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.MezzoTrasporto = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.CausaleTrasporto = ""
         ' FACOLTATIVO - formato numerico; lunghezza massima di 4 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.NumeroColli = 0
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.Descrizione = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 10 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.UnitaMisuraPeso = ""
         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 7 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.PesoLordo = 0
         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 7 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.PesoNetto = 0
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DDTHH:MM:SS.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DataOraRitiro = Today.Date
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DataInizioTrasporto = Today.Date
         ' FACOLTATIVO - codifica del termine di resa (Incoterms) espresso secondo lo standard ICC-Camera di Commercio Internazionale (formato alfanumerico di 3 caratteri)
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.TipoResa = ""

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.IndirizzoResa.Indirizzo = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 8 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.IndirizzoResa.NumeroCivico = ""
         ' OBBLIGATORIO - formato numerico; lunghezza di 5 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.IndirizzoResa.CAP = ""
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.IndirizzoResa.Comune = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.IndirizzoResa.Provincia = ""
         ' OBBLIGATORIO - sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.IndirizzoResa.Nazione = ""

         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DDTHH:MM:SS.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DataOraConsegna = Today.Date

         ' FACOLTATIVO
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.FatturaPrincipale.NumeroFatturaPrincipale = ""
         ' OBBLIGATORIO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiGenerali.FatturaPrincipale.DataFatturaPrincipale = Today.Date
#End Region

#Region "DATI BENI SERVIZI - OBBLIGATORIO "
         ' OBBLIGATORIO
         Dim dettaglioLinee As New FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Add(dettaglioLinee)

         ' OBBLIGATORIO - formato numerico; lunghezza massima di 4 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).NumeroLinea = 0
         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; i ivalori ammessi sono:
         ' SC Sconto
         ' PR Premio
         ' AB Abbuono
         ' AC Spesa accessoria
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).TipoCessionePrestazione = ""

         ' FACOLTATIVO
         Dim codiceArticolo As New FatturaElettronicaBody.DatiBeniServizi.CodiceArticolo
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).CodiceArticolo.Add(codiceArticolo)

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 35 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).CodiceArticolo.Item(0).CodiceTipo = ""
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 35 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).CodiceArticolo.Item(0).CodiceValore = ""

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 1000 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).Descrizione = ""
         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 21 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).Quantita = 0
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 10 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).UnitaMisura = ""
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).DataInizioPeriodo = Today.Date
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).DataFinePeriodo = Today.Date
         ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 21 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).PrezzoUnitario = 0

         ' FACOLTATIVO
         Dim scontoMaggiorazione1 As New Common.ScontoMaggiorazione
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).ScontoMaggiorazione.Add(scontoMaggiorazione1)

         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
         ' SC sconto
         ' MG maggiorazione
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).ScontoMaggiorazione.Item(0).Tipo = ""
         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall’intero con il carattere ‘.’ (punto). La sua lunghezza va da 4 a 6 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).ScontoMaggiorazione.Item(0).Percentuale = 0
         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall’intero con il carattere ‘.’ (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).ScontoMaggiorazione.Item(0).Importo = 0

         ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 21 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).PrezzoTotale = 0
         ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 6 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).AliquotaIVA = 0

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; il valore ammesso è: SI linea di fattura soggetta a ritenuta.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).Ritenuta = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
         ' N1 escluse ex art.15
         ' N2 non soggette
         ' N3 non imponibili
         ' N4 esenti
         ' N5 regime del margine / IVA non esposta in fattura
         ' N6 inversione contabile (per le operazioni in reverse charge ovvero nei casi di autofatturazione per acquisti extra UE di servizi ovvero per importazioni di beni nei soli casi previsti)
         ' N7 IVA assolta In altro stato UE (vendite a distanza ex art. 40 commi 3 e 4 e art. 41 comma 1 lett. b, DL 331/93; prestazione di servizi di telecomunicazioni, tele - radiodiffusione ed elettronici ex art. 7-sexies lett. f, g, DPR 633/72 e art. 74-sexies, DPR 633/72)
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).Natura = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).RiferimentoAmministrazione = ""

         ' FACOLTATIVO
         Dim altriDatiGestionali As New FatturaElettronicaBody.DatiBeniServizi.AltriDatiGestionali
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).AltriDatiGestionali.Add(altriDatiGestionali)

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 10 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).AltriDatiGestionali.Item(0).TipoDato = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).AltriDatiGestionali.Item(0).RiferimentoTesto = ""
         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 21 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).AltriDatiGestionali.Item(0).RiferimentoNumero = 0
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(0).AltriDatiGestionali.Item(0).RiferimentoData = Today.Date

         ' OBBLIGATORIO
         Dim datiRiepilogo As New FatturaElettronicaBody.DatiBeniServizi.DatiRiepilogo
         fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Add(datiRiepilogo)

         ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 6 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(0).AliquotaIVA = 0
         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
         ' N1 escluse ex art.15
         ' N2 non soggette
         ' N3 non imponibili
         ' N4 esenti
         ' N5 regime del margine / IVA non esposta in fattura
         ' N6 inversione contabile (per le operazioni in reverse charge ovvero nei casi di autofatturazione per acquisti extra UE di servizi ovvero per importazioni di beni nei soli casi previsti)
         ' N7 IVA assolta In altro stato UE (vendite a distanza ex art. 40 commi 3 e 4 e art. 41 comma 1 lett. b, DL 331/93; prestazione di servizi di telecomunicazioni, tele - radiodiffusione ed elettronici ex art. 7-sexies lett. f, g, DPR 633/72 e art. 74-sexies, DPR 633/72)
         fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(0).Natura = ""
         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(0).SpeseAccessorie = 0
         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 21 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(0).Arrotondamento = 0
         ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(0).ImponibileImporto = 0
         ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(0).Imposta = 0
         ' FACOLTATIVO - formato alfanumerico; lunghezza di 1 carattere; i valori ammessi sono i seguenti:
         ' I IVA ad esigibilità immediata
         ' D IVA ad esigibilità differita
         ' S scissione dei pagamenti
         fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(0).EsigibilitaIVA = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(0).RiferimentoNormativo = ""
#End Region

#Region "DATI VEICOLI - FACOLTATIVO "
         ' OBBLIGATORIO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiVeicoli.Data = Today.Date
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 15 caratteri.
         fatturaXlm.Body.Item(0).DatiVeicoli.TotalePercorso = ""
#End Region

#Region "DATI PAGAMENTO - FACOLTATIVO "
         ' FACOLTATIVO
         Dim datiPagamento As New FatturaElettronicaBody.DatiPagamento.DatiPagamento
         fatturaXlm.Body.Item(0).DatiPagamento.Add(datiPagamento)

         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 4 caratteri; i valori ammessi sono i seguenti:
         ' TP01 pagamento a rate
         ' TP02 pagamento completo
         ' TP03 anticipo
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).CondizioniPagamento = ""

         ' OBBLIGATORIO
         Dim dettaglioPagamento As New FatturaElettronicaBody.DatiPagamento.DettaglioPagamento
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Add(dettaglioPagamento)

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 200 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).Beneficiario = ""
         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 4 caratteri; i valori ammessi sono i seguenti:
         ' MP01 Contanti
         ' MP02 assegno
         ' MP03 assegno circolare
         ' MP04 Contanti presso Tesoreria
         ' MP05 bonifico
         ' MP06 vaglia cambiario
         ' MP07 bollettino bancario
         ' MP08 carta di pagamento
         ' MP09 RID
         ' MP10 RID utenze
         ' MP11 RID veloce
         ' MP12 Riba
         ' MP13 MAV
         ' MP14 quietanza erario stato
         ' MP15 giroconto su conti di contabilità speciale
         ' MP16 domiciliazione bancaria
         ' MP17 domiciliazione postale
         ' MP18 bollettino di c/c postale
         ' MP19 SEPA Direct Debit
         ' MP20 SEPA Direct Debit CORE
         ' MP21 SEPA Direct Debit B2B
         ' MP22 Trattenuta su somme già riscosse
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).ModalitaPagamento = ""
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).DataRiferimentoTerminiPagamento = Today.Date
         ' FACOLTATIVO - formato numerico di lunghezza massima pari a 3. Vale 0 (zero) per pagamenti a vista.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).GiorniTerminiPagamento = 0
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).DataScadenzaPagamento = Today.Date
         ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).ImportoPagamento = 0
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).CodUfficioPostale = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).CognomeQuietanzante = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).NomeQuietanzante = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza di 16 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).CFQuietanzante = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza che va da 2 a 10 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).TitoloQuietanzante = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 80 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).IstitutoFinanziario = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza che va da 15 a 34 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).IBAN = ""
         ' FACOLTATIVO - formato numerico di 5 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).ABI = ""
         ' FACOLTATIVO - formato numerico di 5 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).CAB = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza che va da 8 a 11 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).BIC = ""
         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).ScontoPagamentoAnticipato = 0
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).DataLimitePagamentoAnticipato = Today.Date
         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).PenalitaPagamentiRitardati = 0
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).DataDecorrenzaPenale = Today.Date
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).CodicePagamento = ""
#End Region

#Region "ALLEGATI - FACOLTATIVO "
         '' FACOLTATIVO
         Dim allegati As New FatturaElettronicaBody.Allegati.Allegati
         fatturaXlm.Body.Item(0).Allegati.Add(allegati)

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         fatturaXlm.Body.Item(0).Allegati.Item(0).NomeAttachment = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 10 caratteri.
         fatturaXlm.Body.Item(0).Allegati.Item(0).AlgoritmoCompressione = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 10 caratteri.
         fatturaXlm.Body.Item(0).Allegati.Item(0).FormatoAttachment = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         fatturaXlm.Body.Item(0).Allegati.Item(0).DescrizioneAttachment = ""
         ' OBBLIGATORIO - è in formato xs:base64Binary.
         Dim allegato As Byte()
         fatturaXlm.Body.Item(0).Allegati.Item(0).Attachment = allegato
#End Region

#End Region

#Region "SCRITTURA DEL FILE XML "
         ' Serializzazione XML
         Dim settings As New XmlWriterSettings()
         settings.Indent = True

         Using writer As XmlWriter = XmlWriter.Create(nomefile, settings)
            fatturaXlm.WriteXml(writer)
         End Using
#End Region

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try

   End Function

   Private Function GeneraDirectoryNomeFileXML() As String
      Try
         Dim nomeFile As String = GeneraNomeFileXML()

         ' Verifica se esiste la cartella dell'anno corrente e in caso contrario la crea.
         If VerificaEsistenzaCartellaAnnoCorrente(nomeDirectory) = False Then
            CreaCartellaAnnoCorrente(nomeDirectory)
         End If

         Dim nomefileXML As String = nomeDirectory & "\" & nomeFile

         Return nomefileXML

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

   Private Function GeneraNomeFileXML() As String
      Try
         Dim nomefileXML As String = eui_cmbTrasmittenteIdPaese.Text.Substring(0, 2) & eui_txtTrasmittenteIdCodice.Text & "_" & LeggiProgressivoFileXML() & ".xml"

         Return nomefileXML

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

   Private Function LeggiProgressivoFileXML() As String
      Try
         ' DA_FARE_A: Sviluppare!

         Return "00001"

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function VerificaEsistenzaCartellaAnnoCorrente(ByVal nomeDir As String) As Boolean
      ' Verifica se esiste la cartella dell'anno corrente.
      Try
         If Directory.Exists(nomeDir) = True Then
            Return True
         Else
            Return False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try

   End Function

   Private Function CreaCartellaAnnoCorrente(ByVal nomeDir As String) As Boolean
      Try
         Directory.CreateDirectory(nomeDir)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Sub FatturaElettronica_Load(sender As Object, e As EventArgs) Handles Me.Load
      Try
         ImpostaIcona(Me)

         ' Percorso file.
         eui_lblDirectoryFileXml.Text = String.Empty

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
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Genera la fattura elettronica in formato xml.
         Dim fileGenerato As Boolean = GeneraFileXML(GeneraDirectoryNomeFileXML)

         ' Se il file xml è stato generato viene visualizzato il nome e il percorso del file.
         If fileGenerato = True Then
            ' Nome file.
            Me.Text = Me.Text & " - " & GeneraNomeFileXML()

            ' Percorso file.
            eui_lblDirectoryFileXml.Text = GeneraDirectoryNomeFileXML()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try

   End Sub

   Private Sub eui_cmdConvalida_Click(sender As Object, e As EventArgs) Handles eui_cmdConvalida.Click
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Convalida la fattura elettronica in formato xml.
         Dim fileConvalidato As Boolean = ConvalidaFileXML(GeneraDirectoryNomeFileXML)

         ' Se il file xml è stato convalidato.
         'If fileConvalidato = True Then

         'End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try

   End Sub

   Private Sub eui_cmdApriCartella_Click(sender As Object, e As EventArgs) Handles eui_cmdApriCartella.Click
      Try
         ' Verifica se esiste la cartella dell'anno corrente e in caso contrario la crea.
         If VerificaEsistenzaCartellaAnnoCorrente(nomeDirectory) = False Then
            CreaCartellaAnnoCorrente(nomeDirectory)
         End If

         AvviaEsploraFile(Me.Handle, nomeDirectory)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdTastiera_Click(sender As Object, e As EventArgs) Handles eui_cmdTastiera.Click
      Try
         AvviaTastieraVirtuale(Me.Handle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdCopiaPercorso_Click(sender As Object, e As EventArgs) Handles eui_cmdCopiaPercorso.Click
      Try
         ' Copia il percorso del file .xml negli appunti di sistema.
         Clipboard.SetText(GeneraDirectoryNomeFileXML)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      Me.Close()

   End Sub

   Private Sub lnkAgenziaEntrate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAgenziaEntrate.LinkClicked
      Try
         ApriSitoInternet("Http://www.agenziaentrate.gov.it")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub lnkFatturaPA_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFatturaPA.LinkClicked
      Try
         ApriSitoInternet("Http://www.fatturapa.gov.it")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub lnkIndicePA_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkIndicePA.LinkClicked
      Try
         ApriSitoInternet("Http://www.indicepa.gov.it")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCpSedeCAP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCpSedeCAP.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCpStabileOrgCAP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCpStabileOrgCAP.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCcSedeCAP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCcSedeCAP.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCcStabileOrgCAP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCcStabileOrgCAP.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCpCapitaleSocialeREA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCpCapitaleSocialeREA.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub
End Class