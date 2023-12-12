import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WordLetterComponent } from './word-letter.component';
import { WordleLetterModel } from "./WordleLetterModel";

describe('WordLetterComponent', () => {
  let component: WordLetterComponent;
  let fixture: ComponentFixture<WordLetterComponent>;
  let nativeElements:HTMLElement;
  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WordLetterComponent],
      providers:[
      {
        provide : WordleLetterModel,
        useValue:new WordleLetterModel()
      }
]
    });
    fixture = TestBed.createComponent(WordLetterComponent);
    component = fixture.componentInstance;  
    nativeElements = fixture.nativeElement ;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it("When letter is empty then should be class wordle-empty-letter", ()=>{
   expect( nativeElements.querySelector('div')?.className).toEqual("wordle-empty-letter");
  })

  it("When letter is good then should be class wordle-good-letter", ()=>{
    component.viewModel.letter = "A";
    
    fixture.detectChanges();
    expect( nativeElements.querySelector('div')?.className).toEqual("wordle-good-letter");
   })
   it("When letter is good then should be class wordle-good-letter", ()=>{
    component.viewModel.letter = "A";
    fixture.detectChanges();
    expect( nativeElements.querySelector('div')?.className).toEqual("wordle-good-letter");
   })
});
