import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { WordleMainModule } from "./wordle-main.module";
import { WordleLetterComponent } from "./word-letter/wordle-letter.component";




@NgModule({
  declarations: [
    AppComponent,
    WordleLetterComponent,    
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
