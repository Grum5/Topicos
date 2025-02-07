package com.raices.pv

import androidx.compose.animation.AnimatedVisibility
import androidx.compose.foundation.Image
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.material.Button
import androidx.compose.material.MaterialTheme
import androidx.compose.material.Text
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.text.TextRange
import org.jetbrains.compose.resources.painterResource
import org.jetbrains.compose.ui.tooling.preview.Preview
import java.awt.Button

@Composable
fun add_button(){
    return (
            Button( onClick = {} ){
                Text("Hola desde una funcion")
            })
}


@Composable
@Preview
fun App() {

    val buttons = mutableListOf(
        add_button(),
        add_button()
    )

    MaterialTheme {

        Column(Modifier.fillMaxWidth(), horizontalAlignment = Alignment.CenterHorizontally) {
            for (item in 0..1){
                buttons[item]
            }
        }
    }
}

