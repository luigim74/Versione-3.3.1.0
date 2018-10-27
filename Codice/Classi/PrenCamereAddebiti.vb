Imports System.Data.OleDb

Public Class PrenCamereAddebiti

   Public RifPren As Integer
   Public Codice As String
   Public Data As String
   Public Descrizione As String
   Public Quantit� As Integer
   Public Importo As String
   Public AliquotaIva As String
   Public Categoria As String
   Public Colore As Integer
   Public Gruppo As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   ' Gestione degli errori.
   Private err As New Varie.Errore
   Private CFormatta As New ClsFormatta

   Public Function LeggiDati(ByVal tabella As String, ByVal codPren As Integer) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE RifPren = " & codPren, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' IdRisorsa
            If IsDBNull(dr.Item("RifPren")) = False Then
               Me.RifPren = Convert.ToInt32(dr.Item("RifPren"))
            Else
               Me.RifPren = codPren
            End If
            ' Codice.
            If IsDBNull(dr.Item("Codice")) = False Then
               Me.Codice = dr.Item("Codice").ToString
            Else
               Me.Codice = String.Empty
            End If
            ' Data.
            If IsDBNull(dr.Item("Data")) = False Then
               Me.Data = dr.Item("Data").ToString
            Else
               Me.Data = String.Empty
            End If
            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               Me.Descrizione = dr.Item("Descrizione").ToString
            Else
               Me.Descrizione = String.Empty
            End If
            ' Quantit�
            If IsDBNull(dr.Item("Quantit�")) = False Then
               Me.Quantit� = Convert.ToInt32(dr.Item("Quantit�"))
            Else
               Me.Quantit� = 1
            End If
            ' Totale.
            If IsDBNull(dr.Item("Importo")) = False Then
               Me.Importo = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Importo")))
            Else
               Me.Importo = VALORE_ZERO
            End If
            ' AliquotaIva.
            If IsDBNull(dr.Item("AliquotaIva")) = False Then
               Me.AliquotaIva = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("AliquotaIva")))
            Else
               Me.AliquotaIva = "0"
            End If
            ' Categoria.
            If IsDBNull(dr.Item("Categoria")) = False Then
               Me.Categoria = dr.Item("Categoria").ToString
            Else
               Me.Categoria = String.Empty
            End If
            ' Colore
            If IsDBNull(dr.Item("Colore")) = False Then
               Me.Colore = Convert.ToInt32(dr.Item("Colore"))
            Else
               Me.Colore = 0
            End If
            ' Gruppo.
            If IsDBNull(dr.Item("Gruppo")) = False Then
               Me.Gruppo = dr.Item("Gruppo").ToString
            Else
               Me.Gruppo = String.Empty
            End If
         Loop

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiDati(ByVal lst As ListView, ByVal tabella As String, ByVal codPren As Integer) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim Caricati As Boolean = False

      Try
         cn.Open()

         Dim i As Integer

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE RifPren = " & codPren, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lst.Items.Clear()

         Do While dr.Read()
            ' Data.
            If IsDBNull(dr.Item("Data")) = False Then
               lst.Items.Add(dr.Item("Data").ToString)
            Else
               lst.Items.Add(String.Empty)
            End If

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Descrizione").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If

            ' Quantit�
            If IsDBNull(dr.Item("Quantit�")) = False Then
               If Convert.ToInt32(dr.Item("Quantit�")) = 0 Then
                  lst.Items(i).SubItems.Add(String.Empty)
               Else
                  lst.Items(i).SubItems.Add(dr.Item("Quantit�").ToString)
               End If
            Else
               lst.Items(i).SubItems.Add("1")
            End If

            ' Importo.
            If IsDBNull(dr.Item("Importo")) = False Then
               lst.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Importo"))))
            Else
               lst.Items(i).SubItems.Add(VALORE_ZERO)
            End If

            ' Codice.
            If IsDBNull(dr.Item("Codice")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Codice").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If

            ' Indice.
            lst.Items(i).SubItems.Add(String.Empty)

            ' AliquotaIva.
            If IsDBNull(dr.Item("AliquotaIva")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("AliquotaIva"))
            Else
               lst.Items(i).SubItems.Add("0")
            End If

            ' Categoria.
            If IsDBNull(dr.Item("Categoria")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Categoria").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If

            'lst.Items(i).BackColor = Color.MediumSeaGreen
            lst.Items(i).ForeColor = Color.FromArgb(Convert.ToInt32(dr.Item("Colore")))
            'lst.Items(i).Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Italic)

            ' Stabilisce il gruppo di appartenenza.
            Dim valGruppo As Short
            Select Case dr.Item("Gruppo").ToString
               Case "Accessori"
                  valGruppo = 1
               Case "Servizi"
                  valGruppo = 2
               Case "Bar/Ristorante"
                  valGruppo = 3
               Case Else ' Articoli vari
                  valGruppo = 0
            End Select

            lst.Items(i).Group = lst.Groups.Item(valGruppo)

            i = i + 1

            Caricati = True
         Loop

         Return Caricati

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         cn.Close()

      End Try
   End Function

   Public Function InserisciDati(ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (RifPren, Codice, Data, Descrizione, Quantit�, Importo, AliquotaIva, Categoria, Colore, Gruppo) " &
                                       "VALUES(@RifPren, @Codice, @Data, @Descrizione, @Quantit�, @Importo, @AliquotaIva, @Categoria, @Colore, @Gruppo)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@RifPren", Me.RifPren)
         cmdInsert.Parameters.AddWithValue("@Codice", Me.Codice)
         cmdInsert.Parameters.AddWithValue("@Data", Me.Data)
         cmdInsert.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.AddWithValue("@Quantit�", Me.Quantit�)
         cmdInsert.Parameters.AddWithValue("@Importo", Me.Importo)
         cmdInsert.Parameters.AddWithValue("@AliquotaIva", Me.AliquotaIva)
         cmdInsert.Parameters.AddWithValue("@Categoria", Me.Categoria)
         cmdInsert.Parameters.AddWithValue("@Colore", Me.Colore)
         cmdInsert.Parameters.AddWithValue("@Gruppo", Me.Gruppo)

         ' Esegue il comando.
         Dim Record As Integer = cmdInsert.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

         Return True

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Public Function ModificaDati(ByVal tabella As String, ByVal codPren As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET RifPren = @RifPren, " &
                             "Codice = @Codice, " &
                             "Data = @Data, " &
                             "Descrizione = @Descrizione, " &
                             "Quantit� = @Quantit�, " &
                             "Importo = @Importo, " &
                             "AliquotaIva = @AliquotaIva, " &
                             "Categoria = @Categoria, " &
                             "Colore = @Colore, " &
                             "Gruppo = @Gruppo " &
                             "WHERE RifPren = {1}",
                             tabella,
                             codPren)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@RifPren", Me.RifPren)
         cmdUpdate.Parameters.AddWithValue("@Codice", Me.Codice)
         cmdUpdate.Parameters.AddWithValue("@Data", Me.Data)
         cmdUpdate.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdUpdate.Parameters.AddWithValue("@Quantit�", Me.Quantit�)
         cmdUpdate.Parameters.AddWithValue("@Importo", Me.Importo)
         cmdUpdate.Parameters.AddWithValue("@AliquotaIva", Me.AliquotaIva)
         cmdUpdate.Parameters.AddWithValue("@Categoria", Me.Categoria)
         cmdUpdate.Parameters.AddWithValue("@Colore", Me.Colore)
         cmdUpdate.Parameters.AddWithValue("@Gruppo", Me.Gruppo)

         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

         Return True

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Function

   Public Function EliminaDati(ByVal tabella As String, ByVal Id As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE RifPren = {1}", tabella, Id)

         ' Crea il comando per la connessione corrente.
         Dim cmdDelete As New OleDbCommand(sql, cn, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdDelete.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

         Return True

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Function

End Class