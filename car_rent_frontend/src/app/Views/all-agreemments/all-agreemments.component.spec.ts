import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllAgreemmentsComponent } from './all-agreemments.component';

describe('AllAgreemmentsComponent', () => {
  let component: AllAgreemmentsComponent;
  let fixture: ComponentFixture<AllAgreemmentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ AllAgreemmentsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllAgreemmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
