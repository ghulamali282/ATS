import { TestBed } from '@angular/core/testing';

import { CcmService } from './services/ccm.service';

describe('CcmService', () => {
  let service: CcmService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CcmService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
