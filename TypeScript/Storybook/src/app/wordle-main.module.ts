import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { WordleLetterComponent } from "./word-letter/wordle-letter.component";
import { WordleGridComponent } from "./wordle-grid/wordle-grid.component";



@NgModule({
    declarations: [   
      WordleLetterComponent,
      WordleGridComponent,
    ],
    imports: [   
      CommonModule,
      FormsModule    
    ], 
     providers: [],
    schemas: [
      CUSTOM_ELEMENTS_SCHEMA,
    ],
  })  
  export class WordleMainModule { }

