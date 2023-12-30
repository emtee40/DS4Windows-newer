# DS4Windows

Versão Ingles  [README](README.md)

DS4Windows - Como outras mas melhor.

DS4Windows é uma aplicação portátil que te permite ter a melhor experiência
com um Dualshock 4 no teu computador. Por meio de emulação , poderás desfrutar
de diversos jogos anteriormente incompativeis com o teu comando DS4. Outros comandos
também são suportados como por exemplo o Dualsense,Switch Pro e Joycons
(**Apenas comandos originais**).

Este projeto é uma afluente do trabalho feito por Jays2Kings.

![DS4Windows Preview](https://raw.githubusercontent.com/Ryochan7/DS4Windows/jay/ds4winwpf_screen_20200412.png)

## Licença de uso

DS4Windows está licenciado sob os termos GNU General Public License version 3.
Poderás encontrar uma cópia dos termos e condições de uso em
[https://www.gnu.org/licenses/gpl-3.0.txt](https://www.gnu.org/licenses/gpl-3.0.txt). Está licença
está tambem disponivel no código fonte no ficheiro COPYING.

## Downloads

- **[Main builds of DS4Windows](https://github.com/Ryochan7/DS4Windows/releases)**

## Requesitos

- Windows 10 ou mais recente (Obrigado Microsoft)
- Microsoft .NET 8.0 Desktop Runtime. [x64](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.0-windows-x64-installer) ou [x86](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.0-windows-x86-installer)
- Visual C++ 2015-2022 Redistributable. [x64](https://aka.ms/vs/17/release/vc_redist.x64.exe) ou [x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)
- [ViGEmBus](https://vigem.org/) driver (DS4Windows instala por ti)
- **Sony** DualShock 4 ou outro comando suportado
- Método de conexão:
  - Cabo micro-usb
  - [Sony Wireless Adapter](https://www.amazon.com/gp/product/B01KYVLKG2)
  - Bluetooth 4.0 (via um
  [adaptador como este](https://www.newegg.com/Product/Product.aspx?Item=N82E16833166126)
  ou instalado diretamente no computador). Apenas o uso do Microsoft BT stack é suportado. CSR BT stack está confirmado que não funciona com o DS4 mesmo que alguns adaptadores CSR funcionem bem com o Microsoft BT stack. Adaptadores da Toshiba não funcionam.
  *Desativar 'Enable output data' na configuração do perfil do comando poderá ajudar com problemas de latência, mas desabilitará o suporte da lightbar e da vibração.*
- Desativa **PlayStation Configuration Support** e
**Xbox Configuration Support** na Steam.
