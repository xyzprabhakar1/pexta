import { TestBed } from '@angular/core/testing';

import { SrvAppDetailService } from './srv-app-detail.service';

describe('SrvAppDetailService', () => {
  let service: SrvAppDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SrvAppDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
