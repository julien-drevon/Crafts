import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WordleProposeComponent } from './wordle-propose.component';
import { By } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { WordleMainModule } from "../wordle-main.module";

describe('WordleProposeComponent', () => {
  let component: WordleProposeComponent;
  let fixture: ComponentFixture<WordleProposeComponent>;
  let nativeElements:HTMLElement;
  
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WordleMainModule]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WordleProposeComponent);
    component = fixture.componentInstance;
    nativeElements = fixture.nativeElement ;
    fixture.detectChanges();
  });
  
  it('should create', () => {  
    expect(component).toBeTruthy();
  }); 
  it('should create', () => {  
    
    let assert;

    component.newProposition.subscribe((e:string)=>{
      assert = e;
    });

    let textInput = fixture.nativeElement.querySelector('input');  
    textInput.value = 'octot';

    fixture.detectChanges();   
      

  
    fixture.nativeElement.querySelector('button').click();
    fixture.detectChanges();
    expect(component.viewModel).toBe('octot');
    expect(assert).toBe('octot');
  });  
}); 



