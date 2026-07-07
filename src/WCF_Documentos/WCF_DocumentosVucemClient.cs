// Decompiled with JetBrains decompiler
// Type: appDocumentosCEDIS.WCF_Documentos.WCF_DocumentosVucemClient
// Assembly: appDocumentosCEDIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D682BDA-0A32-4F25-B153-EB5FE4DE73D8
// Assembly location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.exe
// XML documentation location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.xml

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

#nullable disable
namespace appDocumentosCEDIS.WCF_Documentos;

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

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  InsertaArchivosVucemResponse IWCF_DocumentosVucem.InsertaArchivosVucem(
    InsertaArchivosVucemRequest request)
  {
    return this.Channel.InsertaArchivosVucem(request);
  }

  public bool InsertaArchivosVucem(
    DataTable dtArchivos,
    string tabla,
    string cadenaconexion,
    ref string _Error)
  {
    InsertaArchivosVucemResponse archivosVucemResponse = ((IWCF_DocumentosVucem) this).InsertaArchivosVucem(new InsertaArchivosVucemRequest()
    {
      dtArchivos = dtArchivos,
      tabla = tabla,
      cadenaconexion = cadenaconexion,
      _Error = _Error
    });
    _Error = archivosVucemResponse._Error;
    return archivosVucemResponse.InsertaArchivosVucemResult;
  }

  public Task<InsertaArchivosVucemResponse> InsertaArchivosVucemAsync(
    InsertaArchivosVucemRequest request)
  {
    return this.Channel.InsertaArchivosVucemAsync(request);
  }
}
