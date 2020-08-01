# Minimum Expo project with F# and Fable

This is minimum setup of [Expo](https://expo.io) with F# and Fable (with Elmish). This lets you use Expo platform and SDK in conjunction with F#!

The sample is based on [martinmoec/fable-react-native-how-to](https://github.com/martinmoec/fable-react-native-how-to)

## Requirements

- Node.js
- .NET Core >= 3.0
- yarn
- Expo

## Setup

- `dotnet tool restore`
- `dotnet paket install`
- `yarn install`
- `yarn dev`

## Binding magic in `App.fs`

```fsharp

[<Import("registerRootComponent","expo")>]
let registerRootComponent(componentObj:obj) : unit =
        failwith "JS only"

registerRootComponent (JsInterop.jsConstructor<Components.App>)

```
