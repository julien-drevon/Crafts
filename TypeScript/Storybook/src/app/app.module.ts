import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WordleGridComponent } from '../components/wordle-grid/wordle-grid.component';
import { WordleLineComponent } from './wordle-line/wordle-line.component';
import { WordLetterComponent } from './word-letter/word-letter.component';
import { WordGridComponent } from './word-grid/word-grid.component';

@NgModule({
  declarations: [
    AppComponent,
    WordleGridComponent,
    WordleLineComponent,
    WordLetterComponent,
    WordGridComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
