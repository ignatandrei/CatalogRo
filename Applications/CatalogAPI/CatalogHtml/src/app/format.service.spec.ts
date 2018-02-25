import { TestBed, inject } from '@angular/core/testing';

import { FormatService } from './format.service';

describe('FormatService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FormatService]
    });
  });

  it('should be created', inject([FormatService], (service: FormatService) => {
    expect(service).toBeTruthy();
  }));
});
