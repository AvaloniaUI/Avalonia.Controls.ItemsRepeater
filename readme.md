[![NuGet](https://img.shields.io/nuget/v/Avalonia.Controls.ItemsRepeater.svg)](https://www.nuget.org/packages/Avalonia.Controls.ItemsRepeater/)
# Avalonia `ItemsRepeater`

## Introduction

`ItemsRepeater` control and associated infrastructure ported from the WinUI library: https://github.com/microsoft/microsoft-ui-xaml
Previously this port was part of the Avalonia package itself, but we gradually detach it into separated package and now - separated repository.

## Current Status

The control is currently *retired*.
If possible, it is recommended to use build-in ItemsControl based controls from Avalonia package.
We are still accepting fixes and pull requests for ItemsRepeater controls, and we planning to keep it compatible with latest version of Avalonia up to 12.0 release.
After 12.0 release, this repository will be archived.

## Backporting

ItemsRepeater is still part of 11.0 and 11.1 release branches of the main Avalonia repository.
This package is independent and starts with 11.2 version number, while being usable with any Avalonia from 11.0 version.
If necessary, we can backport any fixes from this repository to 11.1 release branch of the main Avalonia, but second PR needs to be opened in second repo.
