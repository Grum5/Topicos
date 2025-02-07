package com.example

import javafx.application.Application
import javafx.scene.Scene
import javafx.scene.control.Label
import javafx.scene.layout.StackPane
import javafx.stage.Stage

class App : Application() {
    override fun start(primaryStage: Stage) {
        val root = StackPane()
        root.children.add(Label("¡Hola, JavaFX con Kotlin!"))

        val scene = Scene(root, 400.0, 300.0)
        primaryStage.scene = scene
        primaryStage.title = "Aplicación JavaFX con Kotlin"
        primaryStage.show()
    }
}

fun main() {
    Application.launch(App::class.java)
}
