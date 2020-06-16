import { TestBed } from '@angular/core/testing';

import { ProductAttributesService } from './product-attributes.service';

describe('ProductAttributesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProductAttributesService = TestBed.get(ProductAttributesService);
    expect(service).toBeTruthy();
  });
});
