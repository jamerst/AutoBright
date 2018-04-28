# AutoBright  [![GitHub release](https://img.shields.io/github/release/jamerst/AutoBright.svg)](https://github.com/jamerst/AutoBright/releases) [![GitHub release](https://img.shields.io/github/downloads/jamerst/AutoBright/total.svg)](https://github.com/jamerst/AutoBright/releases)
### Scheduled DDC/CI display dimming for Windows

## Features
- Live scheduling based on civil twilight times at a given location
- Support for up to 3 displays (easily expandable)
- ~~Terrible code~~ *Who said that?!*
- External program integration

## Limitations
- Monitors must support DDC/CI properly. Some can be a bit odd, or just not support it at all.
- Monitor support for DDC/CI cannot be checked as there is a bug in the Windows API that returns false results for checking support. *Thanks Microsoft*
- Brightness settings are not tied to specific monitors, the settings are tied to the current monitor number recognized by the system.

## Download
Downloads can be found [here](https://github.com/jamerst/AutoBright/releases)

## Attributions
- DDC/CI control provided by [BrightnessControl](https://github.com/alexhorn/BrightnessControl).
- Scheduling times provided by [sunrise-sunset.org](https://sunrise-sunset.org/)'s free API.
- Special thanks to IronRazer of the DreamInCode forums for assistance with the implementation of BrightnessControl.
