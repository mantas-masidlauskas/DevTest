import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing'

import { EngineerService } from './engineer.service';

describe('EngineerService', () => {
  beforeEach(() => TestBed.configureTestingModule({ 
    imports: [ HttpClientTestingModule ]
  }));

  it('should be created', () => {
    const service: EngineerService = TestBed.get(EngineerService);
    expect(service).toBeTruthy();
  });
});
