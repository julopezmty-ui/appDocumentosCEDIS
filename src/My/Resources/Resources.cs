// Decompiled with JetBrains decompiler
// Type: global::appDocumentosCEDIS.My.Resources.Resources
// Assembly: appDocumentosCEDIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D682BDA-0A32-4F25-B153-EB5FE4DE73D8
// Assembly location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.exe
// XML documentation location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.xml

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace appDocumentosCEDIS.My.Resources;

/// <summary>Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.</summary>
[StandardModule]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
[HideModuleName]
internal sealed class Resources
{
  private static ResourceManager resourceMan;
  private static CultureInfo resourceCulture;

  /// <summary>
  ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static ResourceManager ResourceManager
  {
    get
    {
      if (object.ReferenceEquals((object) global::appDocumentosCEDIS.My.Resources.Resources.resourceMan, (object) null))
        global::appDocumentosCEDIS.My.Resources.Resources.resourceMan = new ResourceManager("appDocumentosCEDIS.Resources", typeof (global::appDocumentosCEDIS.My.Resources.Resources).Assembly);
      return global::appDocumentosCEDIS.My.Resources.Resources.resourceMan;
    }
  }

  /// <summary>
  ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
  ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static CultureInfo Culture
  {
    get => global::appDocumentosCEDIS.My.Resources.Resources.resourceCulture;
    set => global::appDocumentosCEDIS.My.Resources.Resources.resourceCulture = value;
  }
}
