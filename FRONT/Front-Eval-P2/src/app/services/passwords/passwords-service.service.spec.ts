import { TestBed } from '@angular/core/testing';

import { PasswordsService } from './passwords.service';

describe('PasswordsServiceService', () => {
  let service: PasswordsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PasswordsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
