# AutoBright
### Scheduled DDC/CI display dimming for Windows

Lowers display backlight during night hours.

## Features
- Live scheduling based on civil twilight times at a given location (times provided by sunrise-sunset.org)
- Support for up to 3 displays (easily expandable)
- ~~Terrible code~~ *Who said that?!*
- External program integration

## Limitations
- Monitors must support DDC/CI properly. Some can be a bit odd, or just not support it at all.
- Monitor support for DDC/CI cannot be checked - there is a bug in the Windows API that returns false results for checking support. *Thanks Microsoft*
- Brightness settings are not tied to specific monitors, the settings are tied to the current monitor number recognized by the system.
