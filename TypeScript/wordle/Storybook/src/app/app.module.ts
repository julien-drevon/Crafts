import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { WordleMainModule } from "../../../wordle-design/src/wordle-main.module"


@NgModule({
  declarations: [
    AppComponent,
        
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    WordleMainModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
