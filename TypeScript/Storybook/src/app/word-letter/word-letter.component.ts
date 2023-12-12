import { Component } from '@angular/core';
import { WordleLetterModel } from "./WordleLetterModel";

@Component({
  selector: 'app-word-letter',
  templateUrl: './word-letter.component.html',
  styleUrls: ['./word-letter.component.less']
})
export class WordLetterComponent {

  constructor(public   viewModel: WordleLetterModel=new WordleLetterModel()){}
}

