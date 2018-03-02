import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResursaComponent } from './resursa.component';

describe('ResursaComponent', () => {
  let component: ResursaComponent;
  let fixture: ComponentFixture<ResursaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResursaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResursaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
