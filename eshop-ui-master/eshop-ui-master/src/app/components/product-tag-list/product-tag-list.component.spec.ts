import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductTagListComponent } from './product-tag-list.component';

describe('ProductTagListComponent', () => {
  let component: ProductTagListComponent;
  let fixture: ComponentFixture<ProductTagListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductTagListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductTagListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
