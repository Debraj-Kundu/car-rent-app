import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditAgremmentComponent } from './edit-agremment.component';

describe('EditAgremmentComponent', () => {
  let component: EditAgremmentComponent;
  let fixture: ComponentFixture<EditAgremmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ EditAgremmentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditAgremmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
