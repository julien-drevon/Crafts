import type { ComponentFixture} from "@angular/core/testing";
import { TestBed } from "@angular/core/testing";

import { WordleLetterModel, WordleLetterPlacement } from "./WordleLetterModel";
import { WordleLetterComponent } from "./wordle-letter.component";


describe("WordleLetterComponent", () => {

  let component: WordleLetterComponent;
  let fixture: ComponentFixture<WordleLetterComponent>;
  let nativeElements:HTMLElement;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WordleLetterComponent],
      imports:[],
      providers:[
        {
          provide : WordleLetterModel,
          useValue:new WordleLetterModel()
        }
      ]
    });
    fixture = TestBed.createComponent(WordleLetterComponent);
    component = fixture.componentInstance;  
    nativeElements = fixture.nativeElement ;
    fixture.detectChanges();
  });
  
  it("should create", () => {
    expect(component).toBeTruthy();
  });
  
  it("When letter is empty then should be class wordle-empty-letter", ()=>{
    expect( nativeElements.querySelector("div")?.className).toEqual("wordle-empty-letter");
  });
  
  it("When letter is good then should be class wordle-good-letter", ()=>{
    component.viewModel.letter = "A";
    component.viewModel.placement = WordleLetterPlacement.good;
    fixture.detectChanges();
    expect( nativeElements.querySelector("div")?.className).toEqual("wordle-good-letter");
  });

  it("When letter is good then should be class wordle-good-letter", ()=>{
    component.viewModel.letter = "A";
    component.viewModel.placement = WordleLetterPlacement.good;
    fixture.detectChanges();
    expect(nativeElements.querySelector("div")?.className).toEqual("wordle-good-letter");
    expect(nativeElements.querySelector("p")?.textContent).toEqual("A");   
  });
  
  it("When letter is bad placed then should be class wordle-bad-place-letter", ()=>{
    component.viewModel.letter = "A";
    component.viewModel.placement = WordleLetterPlacement.badPlacement;
    fixture.detectChanges();
    
    expect(nativeElements.querySelector("div")?.className).toEqual("wordle-bad-place-letter");
    expect(nativeElements.querySelector("p")?.textContent).toEqual("A");   
  });
  
  it("When letter is wrong  then should be class wordle-wrong-letter", ()=>{
    component.viewModel.letter = "A";
    component.viewModel.placement = WordleLetterPlacement.wrong;
    fixture.detectChanges();
    
    expect(nativeElements.querySelector("div")?.className).toEqual("wordle-wrong-letter");
    expect(nativeElements.querySelector("p")?.textContent).toEqual("A");   
  });
});
