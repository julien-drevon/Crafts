import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";

import { FormsModule } from "@angular/forms";

import {MatGridListModule} from "@angular/material/grid-list";
import { WordleLetterComponent } from "./word-letter/wordle-letter.component";
import { WordleGridComponent } from "./wordle-grid/wordle-grid.component";
import { CommonModule } from "@angular/common";



@NgModule({
    declarations: [   
      WordleLetterComponent,
      WordleGridComponent,
    ],
    exports:[WordleLetterComponent,WordleGridComponent],
    imports: [   
      CommonModule,
      FormsModule,
      MatGridListModule   
    ], 
     providers: [],
    schemas: [
      CUSTOM_ELEMENTS_SCHEMA,
    ],
  })  
  export class WordleMainModule { }

