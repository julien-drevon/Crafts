import type { ComponentFixture} from "@angular/core/testing";
import { TestBed } from "@angular/core/testing";

import { WordleLetterModel, WordleLetterPlacement } from "./WordleLetterModel";
import { WordleLetterComponent } from "./wordle-letter.component";
import { WordleMainModule } from "../wordle-main.module";



describe("WordleLetterComponent", () => {

  let component: WordleLetterComponent;
  let fixture: ComponentFixture<WordleLetterComponent>;
  let nativeElements:HTMLElement;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [],
      imports:[WordleMainModule],
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
    expect( nativeElements.getElementsByClassName("wordle-empty-letter")).toHaveLength(1);
  });
  
  it("When letter is good then should be class wordle-good-letter", ()=>{
    component.viewModel.letter = "A";
    component.viewModel.placement = WordleLetterPlacement.good;
    fixture.detectChanges();
    expect( nativeElements.getElementsByClassName("wordle-good-letter")).toHaveLength(1);
  });

  it("When letter is good then should be class wordle-good-letter", ()=>{
    component.viewModel.letter = "A";
    component.viewModel.placement = WordleLetterPlacement.good;
    fixture.detectChanges();
    expect(nativeElements.getElementsByClassName("wordle-good-letter")).toHaveLength(1);
    expect(nativeElements.querySelector("p")?.textContent).toContain("A");   
  });
  
  it("When letter is bad placed then should be class wordle-bad-place-letter", ()=>{
    component.viewModel.letter = "A";
    component.viewModel.placement = WordleLetterPlacement.badPlacement;
    fixture.detectChanges();
    
    expect(nativeElements.getElementsByClassName("wordle-bad-place-letter")).toHaveLength(1);
    expect(nativeElements.querySelector("p")?.textContent).toContain("A");   
  });
  
  it("When letter is wrong  then should be class wordle-wrong-letter", ()=>{
    component.viewModel.letter = "A";
    component.viewModel.placement = WordleLetterPlacement.wrong;
    fixture.detectChanges();
    
    expect(nativeElements.getElementsByClassName("wordle-wrong-letter")).toHaveLength(1);
    expect(nativeElements.querySelector("p")?.textContent).toContain("A");   
  });
});
