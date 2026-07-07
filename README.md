# Template-Net

Plantilla base de **ITAduax** para crear nuevos repositorios de proyectos **.NET**. Sirve como punto de partida con estructura de carpetas y convenciones comunes, para que todos los equipos arranquen igual.

## Objetivo

- Unificar la organización del código y la documentación en nuevos repos.
- Reducir tiempo de acuerdo sobre dónde va cada cosa.
- Facilitar integración continua (compilación en `src/`, pruebas en `tests/`).

<a id="guia-trabajo-git-itaduax"></a>

## Guía de trabajo y flujo de Git (ITAduax)

Para mantener la estabilidad de los sistemas y la calidad de las entregas, todos los colaboradores deben seguir estas directrices en los repositorios de la organización.

### 1. Estructura de ramas (jerarquía)

El repositorio se organiza en **tres ramas permanentes y protegidas**:

| Rama | Rol | Notas |
|------|-----|--------|
| **main** | Producción | Código estable que está en producción. **Nadie sube aquí directamente**; solo se actualiza mediante Pull Request desde **qas**. |
| **qas** | Pruebas / certificación | Rama del equipo de testing; pruebas de integración. Se despliega en el IIS de QAS. |
| **dev** | Desarrollo | Integración para desarrolladores; aquí se consolidan las nuevas funciones antes de pruebas. Se despliega en el IIS de Desarrollo. |

### 2. Creación de ramas de trabajo

Para cualquier tarea, error o mejora, crea una **rama temporal desde `dev`** con esta nomenclatura:

| Tipo | Prefijo | Ejemplo |
|------|---------|---------|
| Funcionalidad | `feature/id-descripcion` | `feature/45-login-biometrico` |
| Error en DEV/QAS | `bugfix/id-descripcion` | `bugfix/12-error-iva` |
| Error en PROD | `hotfix/id-descripcion` | `hotfix/01-caida-servidor` |

El **id** corresponde al número de **Issue** en el tablero de GitHub del repositorio.

### 3. Ciclo de vida del desarrollo (pipeline)

1. **Inicio:** Crear la rama desde `dev` (por ejemplo `feature/32-api-digitalizacion`).
2. **Desarrollo:** Commits y push de la rama al remoto.
3. **Pull Request hacia `dev`:** Al terminar, abrir un PR a `dev`. **Requisito:** al menos **1 aprobación** de un compañero o líder técnico.
4. **Promoción a `qas`:** Cuando haya tareas listas en `dev`, abrir un PR de `dev` → `qas`. El equipo de Testing valida en el entorno correspondiente.
5. **Paso a producción:** Tras la certificación de QA, PR de **`qas` → `main`**. Aprobación final del Líder de Proyecto y despliegue al IIS de Producción.

### 4. Reglas de protección (branch protection)

En **main**, **qas** y **dev** aplica:

- **Sin push directo:** no se sube código sin Pull Request.
- **Revisiones obligatorias:** al menos **1 aprobación** para poder hacer merge.
- **Historial limpio:** prohibidos los **force push** para evitar pérdida de historial.

### 5. Configuración de identidad local

Para que las contribuciones queden asociadas a tu cuenta institucional, configura Git **dentro de la carpeta del proyecto** bajo `C:/ITAduax/` (o la ruta de tu clon), por ejemplo:

```bash
git config user.name "Tu Nombre"
git config user.email "tu-correo@aduax.com"
```

### 6. Reporte de errores (QA)

Si encuentras un error durante las pruebas en **qas**, abre un Issue usando la plantilla **«Reporte de Bug»** e incluye:

- Pasos para reproducir.
- Resultado esperado frente al obtenido.
- Evidencia (capturas o logs).

---

## Estructura del repositorio

Vista típica desde la **raíz** del repositorio. El punto (`.`) es la carpeta actual; sustituid `NombreDeMiProyecto` por el nombre real de vuestro producto al crear el repo.

```text
.
├── .github/                      # Workflows y plantillas de Pull Request
├── docs/                         # Documentación técnica, diagramas, manuales
├── src/                          # Código fuente (API, librerías, aplicaciones)
├── tests/                        # Pruebas unitarias e integración
├── .gitignore                    # Archivos que Git no debe versionar (build, local, VS)
├── README.md                     # Guía principal del proyecto (este archivo)
└── NombreDeMiProyecto.sln        # Archivo de Solución de Visual Studio
```

| Carpeta / archivo | Uso |
|-------------------|-----|
| `docs/` | Documentación técnica, diagramas, manuales, PBL, DET o estimaciones según normativa del proyecto. |
| `src/` | Código fuente de la solución (API, librerías, aplicaciones). |
| `tests/` | Proyectos de pruebas (unitarias, integración, etc.). |
| `.github/` | Plantillas de Pull Request y workflows de GitHub Actions (cuando se configuren). |
| `.gitignore` | Exclusión de artefactos de Visual Studio, build y archivos locales. |

El archivo `NombreDeMiProyecto.sln` vive en la raíz y agrupa los proyectos bajo `src/` y `tests/`.

## Cómo usar esta plantilla

1. Crear un nuevo repositorio a partir de esta plantilla (o copiar el contenido).
2. Renombrar la solución y los proyectos según el nombre del producto.
3. Mantener `docs/` para documentación que deba vivir junto al código.
4. Añadir `.editorconfig` en la raíz si el equipo define reglas de estilo compartidas (alineado a las directrices de ITAduax).

## Convenciones del equipo

- Ramas, PR y entornos: seguir la sección [Guía de trabajo y flujo de Git (ITAduax)](#guia-trabajo-git-itaduax).
- Los Pull Request deben seguir la plantilla en `.github/PULL_REQUEST_TEMPLATE.md`.
- No versionar secretos ni `appsettings.json` con credenciales reales; usar configuración segura o secretos del entorno o del CI.

## Más información

- Enlazar aquí la wiki, Confluence o normativa interna de arquitectura .NET de **ITAduax** cuando aplique.
- Para el despliegue automático a IIS, usar el workflow en `.github/workflows/` (según cómo lo tenga definido cada repositorio) y la guía siguiente.

### Guía de despliegue automático (ITAduax CI/CD)

Este repositorio puede usar un **pipeline de GitHub Actions** orientado a desplegar aplicaciones **.NET** en **IIS**. El planteamiento habitual es compatible con **.NET Framework (legado)** y con **.NET 7 / 8 / 9**.

#### Requisitos previos obligatorios

Para evitar errores en el despliegue y pérdidas de tiempo en depuración, el proyecto debe cumplir lo siguiente.

##### 1. Perfil de publicación (*Publish Profile*)

El pipeline no “adivina” cómo publicar el proyecto; usa un perfil creado en Visual Studio.

1. En Visual Studio, clic derecho en el proyecto → **Publicar**.
2. Elige **Carpeta** (*Folder*) como destino.
3. En **ubicación de carpeta** (*Folder location*), que sea **`bin\app.publish`** (o equivalente según vuestra convención, alineada al perfil estándar del equipo).
4. El nombre del perfil debe ser exactamente **`FolderProfile`**.
5. **Importante:** el archivo `FolderProfile.pubxml` debe quedar en `Properties/PublishProfiles/` y estar **versionado** en el repositorio cuando el equipo así lo defina.

##### 2. Configuración del servidor (*self-hosted runner*)

En la máquina destino debe haber:

- **Visual Studio 2022 Community** (o *Build Tools*) con la carga **Desarrollo ASP.NET y web**.
- El **Hosting Bundle** de la versión de **.NET** que use la aplicación (si es .NET Core / 7 / 8 / 9).
- El **GitHub Runner** en ejecución con una cuenta con permisos suficientes (**Administrador**, si esa es la política del servidor).

#### Configuración del pipeline (`.yml`)

En cada repositorio se copia o adapta el workflow y se ajustan las variables (por ejemplo en `env:` o en la **matriz** de apps, según la plantilla vigente). **No hace falta** tocar la lógica del script salvo acuerdo de arquitectura.

Ejemplo de variables típicas (referencia; los nombres exactos pueden variar si usáis despliegue multi-app):

```yaml
env:
  # Ruta al .csproj (relativa a la raíz del repo)
  PROJECT_PATH: 'src/TuProyecto.API/TuProyecto.API.csproj'

  # Nombre del perfil en Visual Studio (sin .pubxml)
  PUBLISH_PROFILE: 'FolderProfile'

  # Ruta física en el servidor donde IIS sirve la aplicación
  IIS_TARGET_PATH: 'C:\inetpub\wwwroot\TuCarpetaDestino'

  # Nombre del Application Pool en IIS (debe coincidir con IIS o con lo que cree el workflow)
  IIS_APP_POOL: 'NombreDeTuPool'
```

##### Nombre del Application Pool en IIS

Información rápida para completar **`IIS_APP_POOL`** (o el campo **`pool`** en la matrix del workflow multi-app):

| Concepto | Detalle |
|----------|---------|
| **Qué es** | Identificador del **Application Pool** al que IIS asocia tu sitio o aplicación. El pipeline puede crearlo si no existe, pero el **nombre** debe ser el acordado en el equipo. |
| **Dónde verlo / copiarlo** | En **Administrador de IIS** → **Pools de aplicaciones** (*Application Pools*). El nombre aparece tal cual en la lista (**respetad** mayúsculas y minúsculas si vuestros scripts las distinguen). |
| **Buenas prácticas** | Usar un nombre estable por **entorno** y por **producto**, por ejemplo `MiApiDev`, `MiApiQas` (solo ilustrativo; seguid la convención de ITAduax). |
| **Si falla el despliegue** | Mensajes tipo **«Cannot find APPPOOL»**: el valor en YAML no coincide con IIS. Revisad el nombre en el administrador y actualizad la variable (**`IIS_APP_POOL`** o **`pool`** en matrix). |

#### Resolución de problemas habitual (*troubleshooting*)

| Mensaje / síntoma | Causa probable | Qué revisar |
|-------------------|----------------|-------------|
| *Nothing to do* | El SDK no ve cambios o no resuelve el proyecto. | **`PROJECT_PATH`** correcto y `FolderProfile.pubxml` en **`Properties/PublishProfiles/`**. |
| *Missing NuGet Packages* | Proyectos **.NET Framework** con paquetes clásicos. | El workflow suele usar **NuGet.exe** + **`.sln`** en raíz si aplica. Verificad la solución versionada y las rutas. |
| *Cannot find APPPOOL* | Nombre del pool distinto entre YAML e IIS. | Nombre exacto en **Administrador de IIS** ↔ variable **`IIS_APP_POOL`** (u homónimo en matrix). |
| Carpeta de salida vacía | **`publishUrl`** en el `.pubxml` distinta a la esperada. | Abrid el `.pubxml` y confirmad que **`publishUrl`** apunta a **`bin\app.publish`** (o la ruta acordada). |

#### Flujo de trabajo sugerido (desarrollo)

1. Crear/usar la rama de trabajo del equipo (**`dev`** u otra acordada).  
   `git checkout dev` / `git switch dev`  
2. Implementar cambios y comprobar que compilan **en local**.  
3. Incluir en el commit el **`FolderProfile.pubxml`** si el equipo lo versiona.  
4. `git push origin dev` (u origen/remoto definido).  
5. En GitHub → **Actions**, comprobar que el workflow termina correctamente (**check verde**).

#### Nota de productividad

Si cambiáis la **versión de .NET** (por ejemplo de 8 a 9), no siempre hará falta reescribir el pipeline por eso solo: sí hace falta que el servidor tenga el **runtime** correcto instalado y que el perfil de publicación en Visual Studio esté actualizado para esa versión.

*Mantenido por el equipo de Arquitectura — ITAduax.*

---

## Comandos Git y GitHub (caso práctico)

Tabla de referencia para el día a día. **Git** es el programa en tu PC; **GitHub** es el sitio donde vive una copia del repositorio en internet. Los comandos los escribes en la terminal (PowerShell, CMD o la terminal integrada de Cursor).

### Iniciar sesión en GitHub (día a día)

La forma más simple para el equipo es usar **GitHub CLI** (`gh`). Solo tienes que hacerlo **cuando cambias de máquina**, caduca la sesión o Git te pide credenciales de nuevo.

1. Instala GitHub CLI si no lo tienes (Windows, con **winget**):  
   `winget install --id GitHub.cli -e`
2. Abre la terminal y ejecuta:  
   `gh auth login`
3. Elige **GitHub.com**, protocolo **HTTPS** (recomendado si no usáis SSH en todo el equipo) y **Login with a web browser**: se abrirá el navegador para autorizar con tu cuenta de GitHub.
4. Comprueba que quedó bien:  
   `gh auth status`

Si durante el asistente te pregunta si configurar Git para usar GitHub CLI, puedes decir que **sí**: así `git clone`, `pull` y `push` por HTTPS suelen funcionar sin pegar tokens a mano cada vez.

**Sin instalar `gh`:** Git ya no acepta la contraseña de la web para HTTPS. Hay que crear un **personal access token** en GitHub (**Settings → Developer settings → Personal access tokens**) y usarlo como “contraseña” cuando Git lo pida; en Windows **Git Credential Manager** suele guardarlo para los próximos días.

**SSH:** si el remoto es una URL `git@github.com:...`, la autenticación es por **clave SSH** subida en tu cuenta GitHub; no sustituye el flujo anterior si sigues usando HTTPS.

**Si `gh` no se reconoce** (`El término 'gh' no se reconoce…`): GitHub CLI está instalado pero esta terminal no ve el PATH actualizado. Prueba en este orden:

1. **Cierra la terminal** y abre una nueva (o reinicia Cursor). Vuelve a ejecutar `gh auth login`.
2. Sin cerrar nada, recarga el PATH en PowerShell y prueba de nuevo:
   ```powershell
   $env:Path = [System.Environment]::GetEnvironmentVariable("Path","Machine") + ";" + [System.Environment]::GetEnvironmentVariable("Path","User")
   gh --version
   ```
3. Si sigue fallando, usa la ruta completa del ejecutable (instalación típica en Windows):
   ```powershell
   & "C:\Program Files\GitHub CLI\gh.exe" auth login
   ```
4. Si ni la ruta existe, instala con `winget install --id GitHub.cli -e` y luego el paso 1.

| Comando | Qué hace (en pocas palabras) | Cuándo lo usas |
|--------|------------------------------|----------------|
| `git clone <url>` | Descarga el repositorio de GitHub a tu carpeta local y deja todo listo para trabajar. | Primera vez que tomas un proyecto del equipo. |
| `git status` | Muestra qué archivos cambiaron, cuáles están preparados para guardar en un *commit* y en qué rama estás. | Antes y después de editar; para no perder el hilo. |
| `git pull` | Trae los últimos cambios **desde** GitHub **hacia** tu PC y los mezcla con tu copia local. | Al empezar el día o antes de subir cambios, para no pisar trabajo de otros. |
| `git add <archivo>` | Marca un archivo como “listo” para incluir en el próximo *commit*. | Cuando terminas una parte del cambio y quieres incluirla. |
| `git add .` | Marca **todos** los archivos modificados del directorio actual. | Cuando quieres guardar todo lo que cambiaste (revisa antes con `git status`). |
| `git commit -m "mensaje"` | Guarda una “foto” de los archivos ya añadidos con `add`, con un mensaje que explica qué hiciste. | Cada vez que cierras una mejora o corrección lógica. |
| `git push` | Sube tus *commits* locales **a** GitHub para que el resto del equipo los vea. | Después de uno o varios `commit` cuando quieres publicar en la rama remota. |
| `git fetch` | Descarga información nueva de GitHub **sin** mezclar aún en tus archivos. | Para ver qué hay nuevo sin integrar (luego suele seguir `merge` o `pull`). |
| `git branch` | Lista las ramas locales; con `-a` también ves las remotas. | Para saber en qué “línea de trabajo” estás o cuáles existen. |
| `git checkout <rama>` o `git switch <rama>` | Cambias a otra rama para trabajar en otra funcionalidad. | Cuando pasas de una tarea a otra que vive en otra rama. |
| `git checkout -b <nueva-rama>` o `git switch -c <nueva-rama>` | Crea una rama nueva y te cambias a ella. | Para no mezclar cambios grandes en la rama principal (`main`). |
| `git merge <rama>` | Une los cambios de otra rama **en la rama en la que estás ahora**. | Para integrar trabajo terminado desde una rama de desarrollo. |
| `git log --oneline` | Lista los últimos *commits* en una línea cada uno. | Para ver historial reciente y mensajes de commit. |
| `git diff` | Muestra línea por línea qué cambió respecto al último commit (sin guardar). | Antes de hacer `add`/`commit`, para revisar cambios. |
| `git restore <archivo>` | Deshace cambios **no guardados en commit** en ese archivo (vuelve al estado del último commit). | Si te equivocaste en un archivo y aún no hiciste commit. |
| `git stash` | Guarda temporalmente cambios sin commit para dejar la carpeta “limpia”. | Si debes cambiar de rama urgente y no quieres commitear a medias. |
| `git stash pop` | Recupera lo que guardaste con el último `stash`. | Cuando vuelves a tu tarea y quieres reaplicar esos cambios. |

### Flujo mínimo diario (antes de tocar código)

Objetivo: **partir siempre del mismo estado que el equipo en GitHub** y evitar conflictos o trabajo sobre archivos viejos.

1. Abre la terminal en la carpeta del repositorio (o en Cursor: terminal integrada).  
2. `git status` — confirma en qué rama estás y si hay cambios sin guardar.  
3. Si no es la rama correcta: `git switch nombre-de-la-rama` (la que usa el equipo para esa tarea).  
4. **`git pull`** — trae e integra los últimos cambios del remoto **antes** de editar.  
5. Si `git pull` se queja porque tienes archivos modificados sin *commit*: guarda en un *commit* temporal, o usa `git stash`, luego `git pull`, y después `git stash pop` para recuperar tu trabajo.  
6. Ya puedes editar archivos con tranquilidad.

Repite el paso 4 (y si aplica el 5) **también al volver de una pausa larga** o antes de hacer `push`, si otros pueden haber subido cambios.

### Flujo mínimo típico (equipo principiante)

Ciclo al **cerrar** un cambio y publicarlo (cuando ya terminaste de editar):

1. `git pull` — por si alguien subió algo mientras trabajabas; reduce conflictos al hacer `push`.  
2. `git status` — ver qué archivos vas a incluir.  
3. `git add .` o `git add <archivo>` — preparar lo que quieres guardar.  
4. `git commit -m "Descripción clara del cambio"` — guardar el cambio localmente.  
5. `git push` — subir a GitHub.

### Subir cambios a GitHub (receta rápida)

Es el mismo orden que el **flujo mínimo típico** de arriba, condensado para cuando solo quieres publicar:

1. `git pull`  
2. `git add .` (o archivos concretos)  
3. `git commit -m "Qué cambiaste"`  
4. `git push`

Si es la **primera vez** que subes una rama nueva que solo existe en tu PC, Git puede pedirte enlazarla al remoto. En ese caso (copia el nombre real de tu rama):

```text
git push -u origin nombre-de-tu-rama
```

**Si aparece `Repository not found`:** revisa que el repo exista en GitHub, que la URL sea correcta (`git remote -v`) y que estés autenticado (token personal, GitHub CLI `gh auth login`, o credencial guardada en el Administrador de credenciales de Windows).

### En la web de GitHub (sin terminal)

| Acción | Dónde / qué es |
|--------|----------------|
| **Pull request (PR)** | Pedido para que revisen tu rama y la integren en otra (por ejemplo en `main`). Es el flujo habitual de revisión en equipo. |
| **Fork** | Copia de un repo **en tu cuenta** GitHub (muy usado en proyectos abiertos). |
| **Issues** | Lista de tareas, errores o ideas vinculadas al repositorio. |

*Consejo:* si Git pregunta por usuario y contraseña al hacer `push`, revisa la sección **Iniciar sesión en GitHub (día a día)** más arriba (`gh auth login` o token personal).
