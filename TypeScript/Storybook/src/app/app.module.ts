import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WordleLetterComponent } from "./word-letter/wordle-letter.component";
import { WordleMainModule } from "./wordle-main.module";




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
