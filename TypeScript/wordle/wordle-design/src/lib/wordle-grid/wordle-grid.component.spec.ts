import type { ComponentFixture} from "@angular/core/testing";
import { TestBed } from "@angular/core/testing";
import { WordleGridComponent } from "./wordle-grid.component";
import { WordleLetterComponent } from "../word-letter/wordle-letter.component";
import { WordleLetterPlacement } from "../word-letter/WordleLetterModel";



describe("WordleGridComponent", () => {
  let component: WordleGridComponent;
  let fixture: ComponentFixture<WordleGridComponent>;
  let nativeElements:HTMLElement;
  
  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ 
        WordleLetterComponent,
        WordleGridComponent,],
        imports:[],
      });
      fixture = TestBed.createComponent(WordleGridComponent);
      component = fixture.componentInstance;   
      nativeElements = fixture.nativeElement ;
      fixture.detectChanges();
    });
    
    it("should create", () => {
      expect(component).toBeTruthy();
    });
    
    it("Grid should have 5 column and line and bind letter", () => {    
      expect(nativeElements.getElementsByClassName("wordle-empty-letter")).toHaveLength(25); 
      
      component.viewModel[0].line[1].letter="A";
      component.viewModel[0].line[1].placement= WordleLetterPlacement.good;
      fixture.detectChanges();
      expect(nativeElements.getElementsByClassName("wordle-good-letter")).toHaveLength(1); 
      
    });
  });
  