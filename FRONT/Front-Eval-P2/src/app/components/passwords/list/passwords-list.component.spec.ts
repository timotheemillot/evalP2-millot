import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PasswordsListComponent } from './passwords-list.component';

describe('PasswordsListComponent', () => {
  let component: PasswordsListComponent;
  let fixture: ComponentFixture<PasswordsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PasswordsListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PasswordsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
