import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AjoutBlogComponent } from './ajout-blog.component';

describe('AjoutBlogComponent', () => {
  let component: AjoutBlogComponent;
  let fixture: ComponentFixture<AjoutBlogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AjoutBlogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AjoutBlogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
