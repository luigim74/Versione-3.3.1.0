#Region " DATI FILE.VB "
' ***************************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       29/10/2018
' Data ultima modifica: 04/11/2018
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
         ' Formato di trasmissione.
         Dim fatturaXlm As Fattura
         Select Case eui_cmbFormatoTrasmissione.SelectedIndex
            Case 0
               fatturaXlm = Fattura.CreateInstance(Instance.PubblicaAmministrazione)
            Case 1
               fatturaXlm = Fattura.CreateInstance(Instance.Privati)
         End Select

         ' FATTURA ELETTRONICA HEADER.

         ' DatiTrasmissione.
         fatturaXlm.Header.DatiTrasmissione.IdTrasmittente.IdPaese = eui_cmbTrasmittenteIdPaese.Text.Substring(0, 2)
         fatturaXlm.Header.DatiTrasmissione.IdTrasmittente.IdCodice = eui_txtTrasmittenteIdCodice.Text
         fatturaXlm.Header.DatiTrasmissione.ProgressivoInvio = eui_txtProgressivoInvio.Text
         fatturaXlm.Header.DatiTrasmissione.FormatoTrasmissione = eui_cmbFormatoTrasmissione.Text
         ' DA_FARE: Verificare! Se esiste la PEC inserire 0000000.
         fatturaXlm.Header.DatiTrasmissione.CodiceDestinatario = eui_txtCodiceDestinatario.Text
         fatturaXlm.Header.DatiTrasmissione.ContattiTrasmittente.Telefono = eui_txtTrasmittenteTelefono.Text
         fatturaXlm.Header.DatiTrasmissione.ContattiTrasmittente.Email = eui_txtTrasmittenteEmail.Text
         fatturaXlm.Header.DatiTrasmissione.PECDestinatario = eui_txtTrasmittentePECDestinatario.Text

         ' CedentePrestatore.
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdPaese = eui_cmbCpIdPaese.Text
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdCodice = eui_txtCpIdCodice.Text
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.CodiceFiscale = eui_txtCpCodiceFiscale.Text

         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione = eui_txtCpDenominazione.Text
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Nome = eui_txtCpNome.Text
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Cognome = eui_txtCpCognome.Text
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Titolo = eui_txtCpTitolo.Text
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.CodEORI = eui_txtCpCodiceEORI.Text

         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.AlboProfessionale = eui_txtCpAlboProfessionale.Text
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.ProvinciaAlbo = eui_cmbCpProvinciaAlbo.Text
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.NumeroIscrizioneAlbo = eui_txtCpNumeroIscrizioneAlbo.Text
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.DataIscrizioneAlbo = eui_dtpCpDataIscrizioneAlbo.Value.ToString
         fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.RegimeFiscale = eui_cmbCpRegimeFiscale.Text

         fatturaXlm.Header.CedentePrestatore.Sede.Indirizzo = eui_txtCpSedeIndirizzo.Text
         fatturaXlm.Header.CedentePrestatore.Sede.NumeroCivico = eui_txtCpSedeNumeroCivico.Text
         fatturaXlm.Header.CedentePrestatore.Sede.CAP = eui_txtCpSedeCAP.Text
         fatturaXlm.Header.CedentePrestatore.Sede.Comune = eui_txtCpSedeComune.Text
         fatturaXlm.Header.CedentePrestatore.Sede.Provincia = eui_cmbCpSedeProvincia.Text
         fatturaXlm.Header.CedentePrestatore.Sede.Nazione = eui_cmbCpSedeNazione.Text

         fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.Indirizzo = eui_txtCpStabileOrgIndirizzo.Text
         fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.NumeroCivico = eui_txtCpStabileOrgNumeroCivico.Text
         fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.CAP = eui_txtCpStabileOrgCAP.Text
         fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.Comune = eui_txtCpStabileOrgComune.Text
         fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.Provincia = eui_cmbCpStabileOrgProvincia.Text
         fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.Nazione = eui_cmbCpStabileOrgNazione.Text

         fatturaXlm.Header.CedentePrestatore.IscrizioneREA.Ufficio = eui_cmbCpUfficioREA.Text
         fatturaXlm.Header.CedentePrestatore.IscrizioneREA.NumeroREA = eui_txtCpNumeroREA.Text
         fatturaXlm.Header.CedentePrestatore.IscrizioneREA.CapitaleSociale = Convert.ToDecimal(eui_txtCpCapitaleSocialeREA.Text)
         fatturaXlm.Header.CedentePrestatore.IscrizioneREA.SocioUnico = eui_cmbCpSocioUnicoREA.Text
         fatturaXlm.Header.CedentePrestatore.IscrizioneREA.StatoLiquidazione = eui_cmbCpStatoLiquidazioneREA.Text

         fatturaXlm.Header.CedentePrestatore.Contatti.Telefono = eui_txtCpTelefono.Text
         fatturaXlm.Header.CedentePrestatore.Contatti.Fax = eui_txtCpFax.Text
         fatturaXlm.Header.CedentePrestatore.Contatti.Email = eui_txtCpEmail.Text

         fatturaXlm.Header.CedentePrestatore.RiferimentoAmministrazione = eui_txtCpRifAmministrazione.Text

         ' RappresentanteFiscale.
         fatturaXlm.Header.Rappresentante.DatiAnagrafici.IdFiscaleIVA.IdPaese = eui_cmbRfCpIdPaese.Text
         fatturaXlm.Header.Rappresentante.DatiAnagrafici.IdFiscaleIVA.IdCodice = eui_txtRfCpIdCodice.Text
         fatturaXlm.Header.Rappresentante.DatiAnagrafici.CodiceFiscale = eui_txtRfCpCodiceFiscale.Text

         fatturaXlm.Header.Rappresentante.DatiAnagrafici.Anagrafica.Denominazione = eui_txtRfCpDenominazione.Text
         fatturaXlm.Header.Rappresentante.DatiAnagrafici.Anagrafica.Nome = eui_txtRfCpNome.Text
         fatturaXlm.Header.Rappresentante.DatiAnagrafici.Anagrafica.Cognome = eui_txtRfCpCognome.Text
         fatturaXlm.Header.Rappresentante.DatiAnagrafici.Anagrafica.Titolo = eui_txtRfCpTitolo.Text
         fatturaXlm.Header.Rappresentante.DatiAnagrafici.Anagrafica.CodEORI = eui_txtRfCpCodiceEORI.Text

         ' CessionarioCommittente.
         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdPaese = eui_cmbCcIdPaese.Text
         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice = eui_txtCcIdCodice.Text
         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.CodiceFiscale = eui_txtCcCodiceFiscale.Text

         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.Anagrafica.Denominazione = eui_txtCcDenominazione.Text
         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.Anagrafica.Nome = eui_txtCcNome.Text
         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.Anagrafica.Cognome = eui_txtCcCognome.Text
         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.Anagrafica.Titolo = eui_txtCcTitolo.Text
         fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.Anagrafica.CodEORI = eui_txtCcCodiceEORI.Text

         fatturaXlm.Header.CessionarioCommittente.Sede.Indirizzo = eui_txtCcSedeIndirizzo.Text
         fatturaXlm.Header.CessionarioCommittente.Sede.NumeroCivico = eui_txtCcSedeNumeroCivico.Text
         fatturaXlm.Header.CessionarioCommittente.Sede.CAP = eui_txtCcSedeCAP.Text
         fatturaXlm.Header.CessionarioCommittente.Sede.Comune = eui_txtCcSedeComune.Text
         fatturaXlm.Header.CessionarioCommittente.Sede.Provincia = eui_cmbCcSedeProvincia.Text
         fatturaXlm.Header.CessionarioCommittente.Sede.Nazione = eui_cmbCcSedeNazione.Text

         fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.Indirizzo = eui_txtCcStabileOrgIndirizzo.Text
         fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.NumeroCivico = eui_txtCcStabileOrgNumeroCivico.Text
         fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.CAP = eui_txtCcStabileOrgCAP.Text
         fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.Comune = eui_txtCcStabileOrgComune.Text
         fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.Provincia = eui_cmbCcStabileOrgProvincia.Text
         fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.Nazione = eui_cmbCcStabileOrgNazione.Text

         fatturaXlm.Header.CessionarioCommittente.RappresentanteFiscale.IdFiscaleIVA.IdPaese = eui_cmbCcRfIdPaese.Text
         fatturaXlm.Header.CessionarioCommittente.RappresentanteFiscale.IdFiscaleIVA.IdCodice = eui_txtCcRfIdCodice.Text
         fatturaXlm.Header.CessionarioCommittente.RappresentanteFiscale.Denominazione = eui_txtCcRfDenominazione.Text
         fatturaXlm.Header.CessionarioCommittente.RappresentanteFiscale.Nome = eui_txtCcRfNome.Text
         fatturaXlm.Header.CessionarioCommittente.RappresentanteFiscale.Cognome = eui_txtCcRfCognome.Text

         ' TerzoIntermediari O SoggettoEmittente.
         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.IdFiscaleIVA.IdPaese = eui_cmbTiSeIdPaese.Text
         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.IdFiscaleIVA.IdCodice = eui_txtTiSeIdCodice.Text
         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.CodiceFiscale = eui_txtTiSeCodiceFiscale.Text

         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.Anagrafica.Denominazione = eui_txtTiSeDenominazione.Text
         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.Anagrafica.Nome = eui_txtTiSeNome.Text
         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.Anagrafica.Cognome = eui_txtTiSeCognome.Text
         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.Anagrafica.Titolo = eui_txtTiSeTitolo.Text
         fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.Anagrafica.CodEORI = eui_txtTiSeCodiceEORI.Text

         ' SoggettoEmittente.
         fatturaXlm.Header.SoggettoEmittente = eui_cmbSoggettoEmittente.Text

         ' FATTURA ELETTRONICA BODY.

         Dim fattBody As New FatturaElettronicaBody.Body
         fatturaXlm.Body.Add(fattBody)

         ' Dati Generali.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.TipoDocumento = "TD01"
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Divisa = ""
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Data = Today.Date
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Numero = "1"

         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.TipoRitenuta = ""
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.ImportoRitenuta = 0
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.AliquotaRitenuta = 0
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.CausalePagamento = ""

         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiBollo.BolloVirtuale = ""
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiBollo.ImportoBollo = 0

         Dim datiCassaPrevidenziale As New FatturaElettronicaBody.DatiGenerali.DatiCassaPrevidenziale
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Add(datiCassaPrevidenziale)
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).TipoCassa = ""
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).AlCassa = 0
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).ImportoContributoCassa = 0
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).ImponibileCassa = 0
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).AliquotaIVA = 0
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).Ritenuta = ""
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).Natura = ""
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).RiferimentoAmministrazione = ""

         ' DA_FARE: Sviluppare!

         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.ScontoMaggiorazione.Item(1).Tipo = ""
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.ScontoMaggiorazione.Item(1).Percentuale = 0
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.ScontoMaggiorazione.Item(1).Importo = 0

         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.ImportoTotaleDocumento = 0
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Arrotondamento = 0

         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Causale.Item(1) = 1
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Art73 = ""

         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(1).RiferimentoNumeroLinea.Item(1) = 1
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(1).IdDocumento = ""
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(1).Data = Today.Date
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(1).NumItem = ""
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(1).CodiceCommessaConvenzione = ""
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(1).CodiceCUP = ""
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(1).CodiceCIG = ""

         fatturaXlm.Body.Item(1).DatiGenerali.DatiContratto.Item(1).RiferimentoNumeroLinea.Item(1) = 1
         fatturaXlm.Body.Item(1).DatiGenerali.DatiContratto.Item(1).IdDocumento = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiContratto.Item(1).Data = Today.Date
         fatturaXlm.Body.Item(1).DatiGenerali.DatiContratto.Item(1).NumItem = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiContratto.Item(1).CodiceCommessaConvenzione = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiContratto.Item(1).CodiceCUP = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiContratto.Item(1).CodiceCIG = ""

         fatturaXlm.Body.Item(1).DatiGenerali.DatiConvenzione.Item(1).RiferimentoNumeroLinea.Item(1) = 1
         fatturaXlm.Body.Item(1).DatiGenerali.DatiConvenzione.Item(1).IdDocumento = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiConvenzione.Item(1).Data = Today.Date
         fatturaXlm.Body.Item(1).DatiGenerali.DatiConvenzione.Item(1).NumItem = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiConvenzione.Item(1).CodiceCommessaConvenzione = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiConvenzione.Item(1).CodiceCUP = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiConvenzione.Item(1).CodiceCIG = ""

         fatturaXlm.Body.Item(1).DatiGenerali.DatiRicezione.Item(1).RiferimentoNumeroLinea.Item(1) = 1
         fatturaXlm.Body.Item(1).DatiGenerali.DatiRicezione.Item(1).IdDocumento = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiRicezione.Item(1).Data = Today.Date
         fatturaXlm.Body.Item(1).DatiGenerali.DatiRicezione.Item(1).NumItem = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiRicezione.Item(1).CodiceCommessaConvenzione = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiRicezione.Item(1).CodiceCUP = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiRicezione.Item(1).CodiceCIG = ""

         fatturaXlm.Body.Item(1).DatiGenerali.DatiFattureCollegate.Item(1).RiferimentoNumeroLinea.Item(1) = 1
         fatturaXlm.Body.Item(1).DatiGenerali.DatiFattureCollegate.Item(1).IdDocumento = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiFattureCollegate.Item(1).Data = Today.Date
         fatturaXlm.Body.Item(1).DatiGenerali.DatiFattureCollegate.Item(1).NumItem = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiFattureCollegate.Item(1).CodiceCommessaConvenzione = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiFattureCollegate.Item(1).CodiceCUP = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiFattureCollegate.Item(1).CodiceCIG = ""

         fatturaXlm.Body.Item(1).DatiGenerali.DatiSAL.Item(1).RiferimentoFase = 0

         fatturaXlm.Body.Item(1).DatiGenerali.DatiDDT.Item(1).NumeroDDT = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiDDT.Item(1).DataDDT = Today.Date
         fatturaXlm.Body.Item(1).DatiGenerali.DatiDDT.Item(1).RiferimentoNumeroLinea.Item(1) = 1

         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.IdFiscaleIVA.IdPaese = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.IdFiscaleIVA.IdCodice = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.CodiceFiscale = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.Denominazione = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.Nome = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.Cognome = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.Titolo = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.CodEORI = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.NumeroLicenzaGuida = ""

         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.MezzoTrasporto = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.CausaleTrasporto = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.NumeroColli = 0
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.Descrizione = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.UnitaMisuraPeso = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.PesoLordo = 0
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.PesoNetto = 0
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.DataOraRitiro = Today.Date
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.DataInizioTrasporto = Today.Date
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.TipoResa = ""

         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.IndirizzoResa.Indirizzo = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.IndirizzoResa.NumeroCivico = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.IndirizzoResa.CAP = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.IndirizzoResa.Comune = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.IndirizzoResa.Provincia = ""
         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.IndirizzoResa.Nazione = ""

         fatturaXlm.Body.Item(1).DatiGenerali.DatiTrasporto.DataOraConsegna = Today.Date

         fatturaXlm.Body.Item(1).DatiGenerali.FatturaPrincipale.NumeroFatturaPrincipale = ""
         fatturaXlm.Body.Item(1).DatiGenerali.FatturaPrincipale.DataFatturaPrincipale = Today.Date

         ' DatiBeniServizi.

         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).NumeroLinea = 0
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).TipoCessionePrestazione = ""

         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).CodiceArticolo.Item(1).CodiceTipo = ""
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).CodiceArticolo.Item(1).CodiceValore = ""

         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).Descrizione = ""
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).Quantita = 0
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).UnitaMisura = ""
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).DataInizioPeriodo = Today.Date
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).DataFinePeriodo = Today.Date
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).PrezzoUnitario = 0

         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).ScontoMaggiorazione.Item(1).Tipo = ""
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).ScontoMaggiorazione.Item(1).Percentuale = 0
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).ScontoMaggiorazione.Item(1).Importo = 0

         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).PrezzoTotale = 0
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).AliquotaIVA = 0
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).Ritenuta = ""
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).Natura = ""
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).RiferimentoAmministrazione = ""

         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).AltriDatiGestionali.Item(1).TipoDato = ""
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).AltriDatiGestionali.Item(1).RiferimentoTesto = ""
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).AltriDatiGestionali.Item(1).RiferimentoNumero = 0
         fatturaXlm.Body.Item(1).DatiBeniServizi.DettaglioLinee.Item(1).AltriDatiGestionali.Item(1).RiferimentoData = Today.Date

         fatturaXlm.Body.Item(1).DatiBeniServizi.DatiRiepilogo.Item(1).AliquotaIVA = 0
         fatturaXlm.Body.Item(1).DatiBeniServizi.DatiRiepilogo.Item(1).Natura = ""
         fatturaXlm.Body.Item(1).DatiBeniServizi.DatiRiepilogo.Item(1).SpeseAccessorie = 0
         fatturaXlm.Body.Item(1).DatiBeniServizi.DatiRiepilogo.Item(1).Arrotondamento = 0
         fatturaXlm.Body.Item(1).DatiBeniServizi.DatiRiepilogo.Item(1).ImponibileImporto = 0
         fatturaXlm.Body.Item(1).DatiBeniServizi.DatiRiepilogo.Item(1).Imposta = 0
         fatturaXlm.Body.Item(1).DatiBeniServizi.DatiRiepilogo.Item(1).EsigibilitaIVA = ""
         fatturaXlm.Body.Item(1).DatiBeniServizi.DatiRiepilogo.Item(1).RiferimentoNormativo = ""

         ' DatiVeicoli.

         fatturaXlm.Body.Item(1).DatiVeicoli.Data = Today.Date
         fatturaXlm.Body.Item(1).DatiVeicoli.TotalePercorso = ""

         ' DatiPagamento.

         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).CondizioniPagamento = ""

         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).Beneficiario = ""
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).ModalitaPagamento = ""
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).DataRiferimentoTerminiPagamento = Today.Date
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).GiorniTerminiPagamento = 0
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).DataScadenzaPagamento = Today.Date
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).ImportoPagamento = 0
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).CodUfficioPostale = ""
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).CognomeQuietanzante = ""
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).NomeQuietanzante = ""
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).CFQuietanzante = ""
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).TitoloQuietanzante = ""
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).IstitutoFinanziario = ""
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).IBAN = ""
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).ABI = ""
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).CAB = ""
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).BIC = ""
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).ScontoPagamentoAnticipato = 0
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).DataLimitePagamentoAnticipato = Today.Date
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).PenalitaPagamentiRitardati = 0
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).DataDecorrenzaPenale = Today.Date
         fatturaXlm.Body.Item(1).DatiPagamento.Item(1).DettaglioPagamento.Item(1).CodicePagamento = ""

         ' Allegati.

         fatturaXlm.Body.Item(1).Allegati.Item(1).NomeAttachment = ""
         fatturaXlm.Body.Item(1).Allegati.Item(1).AlgoritmoCompressione = ""
         fatturaXlm.Body.Item(1).Allegati.Item(1).FormatoAttachment = ""
         fatturaXlm.Body.Item(1).Allegati.Item(1).DescrizioneAttachment = ""
         'fatturaXlm.Body.Item(1).Allegati.Item(1).Attachment =

SALTA:

         Dim settings As New XmlWriterSettings()
         settings.Indent = True

         ' Serializzazione XML
         Using writer As XmlWriter = XmlWriter.Create(nomefile, settings)
            fatturaXlm.WriteXml(writer)
         End Using

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try

   End Function

   Private Function GeneraDirectoryNomeFileXML() As String
      Try
         Dim nomeDirectory As String = Application.StartupPath & "\" & CARTELLA_FATTURE_ELETTRONICHE & "\" & Today.Year.ToString
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
End Class