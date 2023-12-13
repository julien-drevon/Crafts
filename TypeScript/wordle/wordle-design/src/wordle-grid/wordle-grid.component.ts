import { Component, Input } from "@angular/core";
import { WordleLetterModel } from "../word-letter/WordleLetterModel";


@Component({
  selector: "wordle-grid",
  templateUrl: "./wordle-grid.component.html",
  styleUrls: ["./wordle-grid.component.less"]
})
export class WordleGridComponent {
  @Input()
  viewModel: WordleWordModel[]=[new WordleWordModel(),new WordleWordModel(),new WordleWordModel(),new WordleWordModel(),new WordleWordModel()];
  
}

export class WordleWordModel{
  constructor(public line:WordleLetterModel[]=    
    [new WordleLetterModel(), new WordleLetterModel(), new WordleLetterModel(), new WordleLetterModel(), new WordleLetterModel()  ]){}
  }