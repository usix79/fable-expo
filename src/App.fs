﻿module App

open Elmish
open Elmish.React
open Elmish.ReactNative
open Fable.Core
open Fable.ReactNative

// A very simple app which increments a number when you press a button

type Model = {
    Counter : int
}

type Message =
    | Increment 

let init () = { Counter = 0 }, Cmd.none

let update msg model =
    match msg  with
    | Increment -> 
        { model with Counter = model.Counter + 1 }, Cmd.none 

module R = Fable.ReactNative.Helpers
module P = Fable.ReactNative.Props
open Fable.ReactNative.Props

let view model dispatch =
    R.view [
        P.ViewProperties.Style [ 
            P.FlexStyle.Flex 1.0 
            P.FlexStyle.JustifyContent JustifyContent.Center
            P.BackgroundColor "#131313" ]
    ] [
        
        
        R.text [
            P.TextProperties.Style [
                P.Color "#ffffff"
            ]
        ] "Press me"
        |> R.touchableHighlightWithChild [
            P.TouchableHighlightProperties.Style [
                P.FlexStyle.Padding ( R.dip 10. )
            ]
            P.TouchableHighlightProperties.UnderlayColor "#f6f6f6"
            OnPress ( fun _ -> dispatch Increment ) 
        ]

        R.text [
            P.TextProperties.Style [
                
                P.Color "#ffffff"
                P.FontSize 30.
                P.TextAlign P.TextAlignment.Center
                
            ]
        ] ( string model.Counter )
    ]

Program.mkProgram init update view
|> Program.withConsoleTrace
|> Program.withReactNative "_" // appKey is not used
|> Program.run

[<Import("registerRootComponent","expo")>]
let registerRootComponent(componentObj:obj) : unit =
        failwith "JS only"
        
registerRootComponent (JsInterop.jsConstructor<Components.App>)