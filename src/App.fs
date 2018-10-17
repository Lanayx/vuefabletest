module fable

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open VueHelpers

// To make dynamic programing less verbose
// we can define a couple of helpers and
let inline private (~%) x = createObj x

let inline private (=>) x y = x ==> y
#nowarn "0058"

type MyData = 
  {
    name: string
  }

let init() =
    let canvas = Browser.document.getElementsByTagName_canvas().[0]
    canvas.width <- 1000.
    canvas.height <- 800.
    let ctx = canvas.getContext_2d()
    // The (!^) operator checks and casts a value to an Erased Union type
    // See http://fable.io/docs/interacting.html#Erase-attribute
    ctx.fillStyle <- !^"rgb(200,0,0)"
    ctx.fillRect (10., 10., 55., 50.)
    ctx.fillStyle <- !^"rgba(0, 0, 200, 0.5)"
    ctx.fillRect (30., 30., 55., 50.)

    let extraOpts = %[
        "el" => "#app"
        "template" => "Hello {{ name }}" 
    ]

        // Now instantiate the type and create a Vue view model
        // using the helper method
    let app = VueHelpers.mount({ name = "World" }, extraOpts)
    Browser.console.log(app)

    // let app = VueHelpers.mount(TodoViewModel(), extraOpts, ".todo-app")
    // let v = new Vue({
    //   el: "#app",
    //   template: '<easy />',
    //   // template: `
    //   // <div>
    //   //     Name: <input v-model="name" type="text">
    //   //     <h1>Hello Component</h1>
    //   //     <hello-component :name="name" :initialEnthusiasm="5" />
    //   //     <h1>Hello Decorator Component</h1>
    //   //     <hello-decorator-component :name="name" :initialEnthusiasm="5" />
    //   //     </div>
    //   // `,
    //   data: { name: "World" },
    //   components: {
    //       HelloComponent,
    //       HelloDecoratorComponent,
    //       Easy
    //   }
    // });

init()