// Decompiled with JetBrains decompiler
// Type: appDocumentosCEDIS.WCF_Respaldo.IWCF_DocumentosVucem
// Assembly: appDocumentosCEDIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D682BDA-0A32-4F25-B153-EB5FE4DE73D8
// Assembly location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.exe
// XML documentation location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.xml

using System.CodeDom.Compiler;
using System.Data;
using System.ServiceModel;
using System.Threading.Tasks;

#nullable disable
namespace appDocumentosCEDIS.WCF_Respaldo;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(ConfigurationName = "WCF_Respaldo.IWCF_DocumentosVucem")]
public interface IWCF_DocumentosVucem
{
  [OperationContract(Action = "http://tempuri.org/IWCF_DocumentosVucem/InsertaArchivosVucem", ReplyAction = "http://tempuri.org/IWCF_DocumentosVucem/InsertaArchivosVucemResponse")]
  bool InsertaArchivosVucem(
    DataTable dtArchivos,
    string tabla,
    string cadenaconexion,
    string _Error);

  [OperationContract(Action = "http://tempuri.org/IWCF_DocumentosVucem/InsertaArchivosVucem", ReplyAction = "http://tempuri.org/IWCF_DocumentosVucem/InsertaArchivosVucemResponse")]
  Task<bool> InsertaArchivosVucemAsync(
    DataTable dtArchivos,
    string tabla,
    string cadenaconexion,
    string _Error);
}
