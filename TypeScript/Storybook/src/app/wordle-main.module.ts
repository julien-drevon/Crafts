import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";

import { FormsModule } from "@angular/forms";

import {MatGridListModule} from "@angular/material/grid-list";
import { WordleLetterComponent } from "./word-letter/wordle-letter.component";
import { WordleGridComponent } from "./wordle-grid/wordle-grid.component";
import { CommonModule } from "@angular/common";
import { WordleProposeComponent } from "./wordle-propose/wordle-propose.component";



@NgModule({
    declarations: [   
      WordleLetterComponent,
      WordleGridComponent,
      WordleProposeComponent
    ],
    exports:[WordleLetterComponent,WordleGridComponent,WordleProposeComponent],
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

