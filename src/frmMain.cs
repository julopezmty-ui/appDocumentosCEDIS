// Decompiled with JetBrains decompiler
// Type: appDocumentosCEDIS.frmMain
// Assembly: appDocumentosCEDIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D682BDA-0A32-4F25-B153-EB5FE4DE73D8
// Assembly location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.exe
// XML documentation location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.xml

using appDocumentosCEDIS.appDocumentosCEDIS.Controllers;
using appDocumentosCEDIS.appDocumentosCEDIS.Entity;
using appDocumentosCEDIS.WCF_Documentos;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace appDocumentosCEDIS;

[DesignerGenerated]
public class frmMain : Form
{
  private Button _btnInicia;
  private System.Windows.Forms.Timer _tmrEnvio;
  private string RutaXML;
  private Configuraciones config;
  private IContainer components;

  public frmMain()
  {
    this.Load += new EventHandler(this.frmMain_Load);
    this.ResizeBegin += new EventHandler(this.frmMain_ResizeBegin);
    this.ResizeEnd += new EventHandler(this.frmMain_ResizeEnd);
    this.InitializeComponent();
  }

  private void frmMain_Load(object sender, EventArgs e)
  {
    this.MinimumSize = (Size) new Point(600, this.Height);
    this.RutaXML = Environment.CurrentDirectory + "\\config.xml";
    this.config = new Configuraciones((object) this.RutaXML);
    this.gvTipos.DataSource = (object) this.config.Archivos;
    this.gvTipos.ReadOnly = false;
    this.showColumns(true);
  }

  private void btnInicia_Click(object sender, EventArgs e)
  {
    this.lblStatu.Text = "INICIADO";
    this.config.ActualizaEstatusXML();
    List<CE_Archivos> archivos = this.config.Archivos;
    archivos.Where<CE_Archivos>(archivo => archivo.estatus).ToList<CE_Archivos>();
    this.tmrEnvio.Enabled = true;
  }

  private void btDetener_Click(object sender, EventArgs e)
  {
    this.lblStatu.Text = "DETENIDO";
    this.tmrEnvio.Enabled = false;
  }

  private DataTable CreaTablaArchivosVucem()
  {
    DataTable dataTable = new DataTable()
    {
      TableName = "vuceDocumentoArchivo"
    };
    dataTable.Columns.Add("id_Archivo");
    dataTable.Columns.Add("Cve_Referencia");
    dataTable.Columns.Add("Cve_Proceso");
    dataTable.Columns.Add("TipoDocumento");
    dataTable.Columns.Add("Id_Num_Doc");
    dataTable.Columns.Add("Ruta");
    dataTable.Columns.Add("Estatus");
    dataTable.Columns.Add("usuario");
    dataTable.Columns.Add("Fec_Registro", Type.GetType("System.DateTime"));
    dataTable.Columns.Add("Edocument");
    dataTable.Columns.Add("RutaRemota");
    dataTable.Columns.Add("Lock");
    dataTable.Columns.Add("NumeroOperacion");
    dataTable.Columns.Add("Error");
    dataTable.Columns.Add("Mensaje");
    dataTable.Columns.Add("HoraRecepcion");
    dataTable.Columns.Add("Enviar");
    dataTable.Columns.Add("UsuarioBloqueo");
    dataTable.Columns.Add("Procesando");
    dataTable.Columns.Add("HoraEdocument");
    dataTable.Columns.Add("Sellos");
    dataTable.Columns.Add("Bloquear");
    return dataTable;
  }

  private void GeneraListado(ref DataTable dtarchivos)
  {
    IEnumerator<CE_Archivos> enumerator1 = (IEnumerator<CE_Archivos>) null;
    IEnumerator enumerator2 = (IEnumerator) null;
    List<CE_Archivos> archivos = this.config.Archivos;
    IEnumerable<CE_Archivos> ceArchivoses = archivos.Where<CE_Archivos>(s => s.estatus);
    try
    {
      try
      {
        foreach (CE_Archivos ceArchivos in ceArchivoses)
        {
          object files;
          try
          {
            files = (object) Directory.GetFiles(ceArchivos.ruta + ceArchivos.carpeta);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            clsLog.SetLog(ex.Message);
            ProjectData.ClearProjectError();
            goto label_23;
          }
          try
          {
            foreach (object obj in (IEnumerable) files)
            {
              object objectValue = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(obj));
              Regex regex = new Regex(this.config.regex, RegexOptions.IgnoreCase);
              FileInfo fileInfo = new FileInfo(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue)));
              if (regex.IsMatch(fileInfo.Name.Replace(fileInfo.Extension, "")) && this.ValidaExtension(fileInfo.Extension))
              {
                string str1 = this.GenerarNombreTemporal(fileInfo.Name.Replace(fileInfo.Extension, ""), ceArchivos.descripcion) + fileInfo.Extension;
                try
                {
                  if (!(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension.ToUpper(), ".JPG", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension.ToUpper(), ".JPEG", false) == 0))
                    File.Move(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue)), objectValue.ToString().Replace(fileInfo.Name, "output\\" + str1));
                  else if (!this.GuardarImagen(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue)), objectValue.ToString().Replace(fileInfo.Name, "output\\" + str1), 1024 /*0x0400*/, 683))
                    goto label_18;
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  clsLog.SetLog($"{ex.Message} Nombre:{str1}");
                  ProjectData.ClearProjectError();
                  goto label_18;
                }
                DataRow row = dtarchivos.NewRow();
                string[] strArray1 = fileInfo.Name.Replace(fileInfo.Extension, "").Split('_');
                string str2 = strArray1[0];
                string proc = new string(strArray1[1].Take<char>(1).ToArray<char>());
                row["Cve_Referencia"] = (object) str2;
                row["Cve_Proceso"] = (object) this.EvalueProceso(proc);
                row["TipoDocumento"] = (object) "ANEXO";
                row["Id_Num_Doc"] = (object) this.EsFOTO(proc, ceArchivos.id_num_doc);
                row["Ruta"] = (object) objectValue.ToString().Replace(fileInfo.Name, "output\\" + str1);
                row["Estatus"] = (object) "A";
                row["usuario"] = (object) "Automatico";
                row["Fec_Registro"] = (object) DateAndTime.Now;
                row["Edocument"] = (object) "";
                row["NumeroOperacion"] = (object) "";
                row["Error"] = (object) 0;
                row["Mensaje"] = (object) "";
                DataRow dataRow1 = row;
                DateTime now = DateTime.Now;
                string str3 = now.ToString("yyyy/MM/dd");
                dataRow1["HoraRecepcion"] = (object) str3;
                row["UsuarioBloqueo"] = (object) "";
                DataRow dataRow2 = row;
                now = DateTime.Now;
                string str4 = now.ToString("yyyy/MM/dd");
                dataRow2["HoraEdocument"] = (object) str4;
                row["Bloquear"] = (object) 0;
                string[] strArray2 = new string[7];
                strArray2[0] = "/";
                string[] strArray3 = strArray2;
                string[] strArray4 = strArray3;
                now = DateTime.Now;
                string str5 = now.Year.ToString();
                strArray4[1] = str5;
                strArray3[2] = "/";
                int num = DateAndTime.DatePart(DateInterval.WeekOfYear, DateAndTime.Now);
                strArray3[3] = num.ToString();
                strArray3[4] = "/";
                strArray3[5] = this.GenerarNombre(fileInfo.Name.Replace(fileInfo.Extension, ""), ceArchivos.descripcion);
                strArray3[6] = fileInfo.Extension;
                row["RutaRemota"] = (object) string.Concat(strArray3);
                row["Lock"] = (object) "0";
                row["Enviar"] = (object) "0";
                row["Procesando"] = (object) "0";
                row["Sellos"] = (object) "0";
                dtarchivos.Rows.Add(row);
              }
label_18:;
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
label_23:;
        }
      }
      finally
      {
        enumerator1?.Dispose();
      }
    }
    catch (Exception ex)
    {
      ProjectData.SetProjectError(ex);
      clsLog.SetLog(ex.Message);
      ProjectData.ClearProjectError();
    }
  }

  private void tmrEnvio_Tick(object sender, EventArgs e)
  {
    this.tmrEnvio.Enabled = false;
    try
    {
      DataTable dataTable = this.CreaTablaArchivosVucem();
      this.GeneraListado(ref dataTable);
      if (Information.IsNothing((object) dataTable) || dataTable.Rows.Count <= 0)
        return;
      ManejoAWS.sendFileS3(ref dataTable);
      List<DataTable> dataTableList1 = this.SplitDatatable(dataTable, 20);
      int num1 = checked (dataTableList1.Count - 1);
      int num2 = 0;
      do
      {
        clsLog.SetLog("Entro a ciclo se envios: " + Conversions.ToString((object) num2));
        List<DataTable> dataTableList2 = dataTableList1;
        int index = num2;
        DataTable dtarchivos = dataTableList2[index];
        this.EnvioWS(ref dtarchivos);
        dataTableList2[index] = dtarchivos;
        checked { ++num2; }
      }
      while (num2 <= num1);
      clsLog.SetLog("Paso 5");
    }
    catch (Exception ex)
    {
      ProjectData.SetProjectError(ex);
      clsLog.SetLog(ex.Message);
      ProjectData.ClearProjectError();
    }
    finally
    {
      this.tmrEnvio.Enabled = true;
    }
  }

  private string GenerarNombre(string NombreArchivo, string descripcion)
  {
    Thread.Sleep(10);
    string[] strArray = NombreArchivo.Split('_');
    string str1 = strArray[0];
    string str2 = strArray[1];
    return str1 + descripcion + DateAndTime.Now.Hour.ToString() + DateAndTime.Now.Minute.ToString() + DateAndTime.Now.Second.ToString() + DateAndTime.Now.Millisecond.ToString();
  }

  private string GenerarNombreTemporal(string NombreArchivo, string descripcion)
  {
    Thread.Sleep(10);
    string[] strArray = NombreArchivo.Split('_');
    return $"{strArray[0]}_{strArray[1]}{DateAndTime.Now.Hour.ToString()}{DateAndTime.Now.Minute.ToString()}{DateAndTime.Now.Second.ToString()}{DateAndTime.Now.Millisecond.ToString()}";
  }

  private bool GuardarImagen(string original, string guardado, int alto, int ancho)
  {
    bool flag1;
    bool flag2;
    try
    {
      Image image1;
      using (FileStream fileStream = new FileStream(original, FileMode.Open, FileAccess.Read))
        image1 = Image.FromStream((Stream) fileStream);
      Image image2 = (Image) new Bitmap(alto, ancho);
      using (Graphics graphics = Graphics.FromImage(image2))
      {
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.DrawImage(image1, 0, 0, alto, ancho);
      }
      EncoderParameters encoderParams = new EncoderParameters(1);
      EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, 80L /*0x50*/);
      encoderParams.Param[0] = encoderParameter;
      ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
      ImageCodecInfo encoder = ((IEnumerable<ImageCodecInfo>) imageEncoders).Where<ImageCodecInfo>(s => Microsoft.VisualBasic.CompilerServices.Operators.CompareString(s.MimeType, "image/jpeg", false) == 0).ToArray<ImageCodecInfo>()[0];
      image1.Dispose();
      GC.Collect();
      image2.Save(guardado, encoder, encoderParams);
      int num = 0;
      while (true)
      {
        try
        {
          File.Delete(original);
          break;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          clsLog.SetLog(ex.Message);
          if (num > 6)
          {
            flag1 = false;
            ProjectData.ClearProjectError();
            goto label_23;
          }
          checked { ++num; }
          ProjectData.ClearProjectError();
        }
      }
      flag2 = true;
    }
    catch (Exception ex)
    {
      ProjectData.SetProjectError(ex);
      flag2 = false;
      ProjectData.ClearProjectError();
    }
    flag1 = flag2;
label_23:
    return flag1;
  }

  private bool RegresaArchivos(DataTable dtarchivos)
  {
    IEnumerator enumerator = (IEnumerator) null;
    bool flag = false;
    try
    {
      try
      {
        foreach (DataRow row in dtarchivos.Rows)
        {
          int num = 0;
          try
          {
            row["Ruta"].ToString();
            RuntimeHelpers.GetObjectValue(row["Ruta"]);
            string[] strArray = new string[2]
            {
              "output\\",
              ""
            };
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            if (checked (num + 1) < 8)
              clsLog.SetLog(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Hay que mover archivo de regreso: ", RuntimeHelpers.GetObjectValue(row["Ruta"])).ToString());
            ProjectData.ClearProjectError();
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }
    catch (Exception ex)
    {
      ProjectData.SetProjectError(ex);
      clsLog.SetLog(ex.Message);
      ProjectData.ClearProjectError();
    }
    try
    {
      new ManejoFTP(this.config.FTP.User, this.config.FTP.Pass, this.config.FTP.Server).eliminarFtpMasivo(dtarchivos);
    }
    catch (Exception ex)
    {
      ProjectData.SetProjectError(ex);
      clsLog.SetLog(ex.Message);
      ProjectData.ClearProjectError();
    }
    return flag;
  }

  private List<DataTable> SplitDatatable(DataTable dt, int segmento)
  {
    List<DataTable> dataTableList1 = (List<DataTable>) null;
    try
    {
      int num1 = checked ((int) Math.Round(Math.Ceiling(unchecked ((double) dt.Rows.Count / (double) segmento))));
      List<DataTable> dataTableList2 = new List<DataTable>();
      int num2 = num1;
      int num3 = 1;
      do
      {
        int count = checked (num3 - 1 * segmento);
        DataTable dataTable = dt.AsEnumerable().Skip<DataRow>(count).Take<DataRow>(segmento).CopyToDataTable<DataRow>();
        dataTable.TableName = "Tabla" + num3.ToString();
        dataTableList2.Add(dataTable);
        checked { ++num3; }
      }
      while (num3 <= num2);
      return dataTableList2;
    }
    catch (Exception ex)
    {
      ProjectData.SetProjectError(ex);
      clsLog.SetLog(ex.Message);
      ProjectData.ClearProjectError();
    }
    return dataTableList1;
  }

    private void EnvioWS(ref DataTable dtarchivos)
    {
        string _Error = "";
        int num = 0;
        bool flag = false;
        clsLog.SetLog("Enviando a WS");

        // NOTA: El cliente ya no se crea aquí afuera

        while (num <= 4 && !flag)
        {
            clsLog.SetLog("entro WS (Intento " + (num + 1) + ")");

            // Creamos una nueva instancia del cliente para ESTE intento
            WCF_DocumentosVucemClient documentosVucemClient = new WCF_DocumentosVucemClient();

            try
            {
                if (!documentosVucemClient.InsertaArchivosVucem(dtarchivos, "vuceDocumentoArchivo", "Data Source=GRUPOEIDB3;Initial Catalog=Aduasis;User ID=sa;Password=linemex10", ref _Error))
                {
                    clsLog.SetLog("Ocurrio un error al registrar archivos en bd " + _Error);
                    this.RegresaArchivos(dtarchivos);
                }

                clsLog.SetLog("Envío Correcto, awsPath: " + dtarchivos.Rows[0]["RutaRemota"].ToString());
                flag = true;

                // Si todo sale bien, cerramos el canal limpiamente
                documentosVucemClient.Close();
            }
            catch (Exception ex1)
            {
                clsLog.SetLog("Error 450");
                ProjectData.SetProjectError(ex1);
                Exception exception = ex1;
                clsLog.SetLog(exception.Message);

                try
                {
                    if (exception.InnerException != null)
                        clsLog.SetLog(exception.InnerException.Message);
                }
                catch (Exception ex2)
                {
                    clsLog.SetLog("Error 462");
                    ProjectData.SetProjectError(ex2);
                    ProjectData.ClearProjectError();
                }

                // CRUCIAL: Como falló, abortamos el canal viejo para liberar recursos
                try
                {
                    documentosVucemClient.Abort();
                }
                catch { /* Ignorar errores al abortar */ }

                checked { ++num; }
                if (num >= 4)
                    this.RegresaArchivos(dtarchivos);

                ProjectData.ClearProjectError();
            }
        }
        clsLog.SetLog(_Error);
    }

    private void EnvioFTP(ref DataTable dtArchivos)
  {
    IEnumerator enumerator = (IEnumerator) null;
    ManejoFTP manejoFtp = new ManejoFTP(this.config.FTP.User, this.config.FTP.Pass, this.config.FTP.Server);
    string[] strArray = new string[5]
    {
      "\\",
      DateTime.Now.Year.ToString(),
      "\\",
      null,
      null
    };
    int num1 = DateAndTime.DatePart(DateInterval.WeekOfYear, DateAndTime.Now);
    strArray[3] = num1.ToString();
    strArray[4] = "\\";
    string ruta_ftp = string.Concat(strArray);
    try
    {
      foreach (DataRow row in dtArchivos.Rows)
      {
        string nombre = row["RutaRemota"].ToString().Split('/')[checked (row["RutaRemota"].ToString().Split('/').Length - 1)];
        if (!manejoFtp.enviarFtp(Conversions.ToString(RuntimeHelpers.GetObjectValue(row["Ruta"])), ruta_ftp, nombre))
        {
          int num2 = 0;
          row["EnviadoFTP"] = (object) "0";
          try
          {
            Conversions.ToString(RuntimeHelpers.GetObjectValue(row["Ruta"]));
            RuntimeHelpers.GetObjectValue(row["Ruta"]);
            object[] objArray = new object[2]
            {
              (object) "output\\",
              (object) ""
            };
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            if (checked (num2 + 1) < 8)
              clsLog.SetLog(exception.Message);
            ProjectData.ClearProjectError();
          }
        }
        else
          row["EnviadoFTP"] = (object) "1";
      }
    }
    finally
    {
      if (enumerator is IDisposable)
        (enumerator as IDisposable).Dispose();
    }
    int length = dtArchivos.Select("EnviadoFTP=0").Length;
    while (dtArchivos.Select("EnviadoFTP=0").Length > 0)
      dtArchivos.Rows.Remove(dtArchivos.Select("EnviadoFTP=0")[0]);
    dtArchivos.Columns.Remove("EnviadoFTP");
  }

  private string EsFOTO(string proc, string num_doc)
  {
    IEnumerable<CE_Procesos> source = this.config.Procesos.Where<CE_Procesos>(s => Microsoft.VisualBasic.CompilerServices.Operators.CompareString(s.id.ToUpper(), proc.ToUpper(), false) == 0);
    return !Conversions.ToBoolean((object) source.Select<CE_Procesos, string>(s => s.esfoto).ToArray<string>()[0].ToString()) ? num_doc : "14";
  }

  private string EvalueProceso(string proc)
  {
    IEnumerable<CE_Procesos> source = this.config.Procesos.Where<CE_Procesos>(s => Microsoft.VisualBasic.CompilerServices.Operators.CompareString(s.id.ToUpper(), proc.ToUpper(), false) == 0);
    return source.Select<CE_Procesos, string>(s => s.descripcion).ToArray<string>()[0].ToString();
  }

  private bool ValidaExtension(string @extension)
  {
    string upper = @extension.ToUpper();
    return Microsoft.VisualBasic.CompilerServices.Operators.CompareString(upper, ".JPG", false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(upper, ".JPEG", false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(upper, ".PDF", false) == 0;
  }

  private void frmMain_ResizeBegin(object sender, EventArgs e)
  {
    if (this.Width <= 600)
    {
      this.showColumns(false);
      this.Width = 600;
    }
    else
      this.showColumns(true);
    this.Height = 350;
  }

  private void showColumns(bool all)
  {
    if (all)
    {
      foreach (DataGridViewColumn column in (BaseCollection) this.gvTipos.Columns)
        column.Visible = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(column.Name, "carpeta", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(column.Name, "estatus", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(column.Name, "descripcion", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(column.Name, "ruta", false) == 0;
    }
    else
    {
      foreach (DataGridViewColumn column in (BaseCollection) this.gvTipos.Columns)
        column.Visible = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(column.Name, "carpeta", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(column.Name, "estatus", false) == 0;
    }
  }

  private void frmMain_ResizeEnd(object sender, EventArgs e)
  {
    if (this.Width <= 600)
      this.showColumns(false);
    else
      this.showColumns(true);
  }

  [DebuggerNonUserCode]
  protected override void Dispose(bool disposing)
  {
    try
    {
      if (!disposing || this.components == null)
        return;
      this.components.Dispose();
    }
    finally
    {
      base.Dispose(disposing);
    }
  }

  [DebuggerStepThrough]
  private void InitializeComponent()
  {
    this.components = (IContainer) new System.ComponentModel.Container();
    this.gvTipos = new DataGridView();
    this.btnInicia = new Button();
    this.Button1 = new Button();
    this.Label1 = new Label();
    this.lblStatu = new Label();
    this.tmrEnvio = new System.Windows.Forms.Timer(this.components);
    ((ISupportInitialize) this.gvTipos).BeginInit();
    this.SuspendLayout();
    this.gvTipos.AllowUserToAddRows = false;
    this.gvTipos.AllowUserToDeleteRows = false;
    this.gvTipos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.gvTipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    this.gvTipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.gvTipos.Location = new Point(12, 29);
    this.gvTipos.Name = "gvTipos";
    this.gvTipos.Size = new Size(782, 210);
    this.gvTipos.TabIndex = 0;
    this.btnInicia.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
    this.btnInicia.BackColor = Color.FromArgb(128 /*0x80*/, (int) byte.MaxValue, 128 /*0x80*/);
    this.btnInicia.Font = new Font("Century Gothic", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.btnInicia.Location = new Point(12, 245);
    this.btnInicia.Name = "btnInicia";
    this.btnInicia.Size = new Size(184, 58);
    this.btnInicia.TabIndex = 1;
    this.btnInicia.Text = "INICIAR";
    this.btnInicia.UseVisualStyleBackColor = false;
    this.Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
    this.Button1.BackColor = Color.FromArgb((int) byte.MaxValue, 128 /*0x80*/, 128 /*0x80*/);
    this.Button1.Font = new Font("Century Gothic", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.Button1.Location = new Point(202, 245);
    this.Button1.Name = "Button1";
    this.Button1.Size = new Size(184, 58);
    this.Button1.TabIndex = 2;
    this.Button1.Text = "DETENER";
    this.Button1.UseVisualStyleBackColor = false;
    this.Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.Label1.Location = new Point(609, 253);
    this.Label1.Name = "Label1";
    this.Label1.Size = new Size(185, 22);
    this.Label1.TabIndex = 3;
    this.Label1.Text = "Estatus:";
    this.Label1.TextAlign = ContentAlignment.MiddleCenter;
    this.lblStatu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.lblStatu.Font = new Font("Microsoft Tai Le", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.lblStatu.ForeColor = Color.FromArgb((int) byte.MaxValue, 128 /*0x80*/, 128 /*0x80*/);
    this.lblStatu.Location = new Point(609, 275);
    this.lblStatu.Name = "lblStatu";
    this.lblStatu.Size = new Size(185, 22);
    this.lblStatu.TabIndex = 4;
    this.lblStatu.Text = "[ESTATUS]";
    this.lblStatu.TextAlign = ContentAlignment.MiddleCenter;
    this.AutoScaleDimensions = new SizeF(7f, 16f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.BackColor = Color.White;
    this.ClientSize = new Size(806, 311);
    this.Controls.Add((Control) this.lblStatu);
    this.Controls.Add((Control) this.Label1);
    this.Controls.Add((Control) this.Button1);
    this.Controls.Add((Control) this.btnInicia);
    this.Controls.Add((Control) this.gvTipos);
    this.Font = new Font("Microsoft Tai Le", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.Margin = new Padding(4);
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.Name = nameof (frmMain);
    this.Text = "Agente Documentos Vucem";
    ((ISupportInitialize) this.gvTipos).EndInit();
    this.ResumeLayout(false);
  }

  [field: AccessedThroughProperty("gvTipos")]
  internal virtual DataGridView gvTipos { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

  internal virtual Button btnInicia
  {
    get => this._btnInicia;
    [MethodImpl(MethodImplOptions.Synchronized)] set
    {
      EventHandler eventHandler = new EventHandler(this.btnInicia_Click);
      Button btnInicia1 = this._btnInicia;
      if (btnInicia1 != null)
        btnInicia1.Click -= eventHandler;
      this._btnInicia = value;
      Button btnInicia2 = this._btnInicia;
      if (btnInicia2 == null)
        return;
      btnInicia2.Click += eventHandler;
    }
  }

  [field: AccessedThroughProperty("Button1")]
  internal virtual Button Button1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

  [field: AccessedThroughProperty("Label1")]
  internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

  [field: AccessedThroughProperty("lblStatu")]
  internal virtual Label lblStatu { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

  internal virtual System.Windows.Forms.Timer tmrEnvio
  {
    get => this._tmrEnvio;
    [MethodImpl(MethodImplOptions.Synchronized)] set
    {
      EventHandler eventHandler = new EventHandler(this.tmrEnvio_Tick);
      System.Windows.Forms.Timer tmrEnvio1 = this._tmrEnvio;
      if (tmrEnvio1 != null)
        tmrEnvio1.Tick -= eventHandler;
      this._tmrEnvio = value;
      System.Windows.Forms.Timer tmrEnvio2 = this._tmrEnvio;
      if (tmrEnvio2 == null)
        return;
      tmrEnvio2.Tick += eventHandler;
    }
  }
}
