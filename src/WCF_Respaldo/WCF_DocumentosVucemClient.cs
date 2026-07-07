// Decompiled with JetBrains decompiler
// Type: appDocumentosCEDIS.WCF_Respaldo.WCF_DocumentosVucemClient
// Assembly: appDocumentosCEDIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D682BDA-0A32-4F25-B153-EB5FE4DE73D8
// Assembly location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.exe
// XML documentation location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.xml

using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

#nullable disable
namespace appDocumentosCEDIS.WCF_Respaldo;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class WCF_DocumentosVucemClient : ClientBase<IWCF_DocumentosVucem>, IWCF_DocumentosVucem
{
  public WCF_DocumentosVucemClient()
  {
  }

  public WCF_DocumentosVucemClient(string endpointConfigurationName)
    : base(endpointConfigurationName)
  {
  }

  public WCF_DocumentosVucemClient(string endpointConfigurationName, string remoteAddress)
    : base(endpointConfigurationName, remoteAddress)
  {
  }

  public WCF_DocumentosVucemClient(string endpointConfigurationName, EndpointAddress remoteAddress)
    : base(endpointConfigurationName, remoteAddress)
  {
  }

  public WCF_DocumentosVucemClient(Binding binding, EndpointAddress remoteAddress)
    : base(binding, remoteAddress)
  {
  }

  public bool InsertaArchivosVucem(
    DataTable dtArchivos,
    string tabla,
    string cadenaconexion,
    string _Error)
  {
    return this.Channel.InsertaArchivosVucem(dtArchivos, tabla, cadenaconexion, _Error);
  }

  public Task<bool> InsertaArchivosVucemAsync(
    DataTable dtArchivos,
    string tabla,
    string cadenaconexion,
    string _Error)
  {
    return this.Channel.InsertaArchivosVucemAsync(dtArchivos, tabla, cadenaconexion, _Error);
  }
}
