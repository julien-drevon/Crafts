import { Component, Input } from '@angular/core';
import { WordleLetterModel, WordleLetterPlacement } from './WordleLetterModel';

@Component({
  selector: 'app-word-letter',
  templateUrl: './word-letter.component.html',
  styleUrls: ['./word-letter.component.less']
})
export class WordLetterComponent {
  @Input()
  viewModel: WordleLetterModel = new WordleLetterModel(); 
  
  convertWordLetterModelToWordCss(letterModel:WordleLetterModel):string{
    if( !letterModel.letter)
    return 'wordle-empty-letter';    
    
    return getColorPlacementForNonEmptyLetter(letterModel);
  } 
}

function getColorPlacementForNonEmptyLetter(letterModel:WordleLetterModel):string
{
  switch(letterModel.placement){
    case WordleLetterPlacement.badPlacement:
    return "wordle-bad-place-letter";
    
    case WordleLetterPlacement.wrong:
    return "wordle-wrong-letter";
    
    case WordleLetterPlacement.good :      
    return "wordle-good-letter";
    
    case WordleLetterPlacement.empty:
    default  :
    return"wordle-empty-letter";      
  }
}

