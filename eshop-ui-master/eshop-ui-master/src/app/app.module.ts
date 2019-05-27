import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { AboutComponent } from './components/about/about.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { ProductInputComponent } from './components/product-input/product-input.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { ProductTagListComponent } from './components/product-tag-list/product-tag-list.component';


const appRoutes: Routes = [
  {path: 'products', component: ProductListComponent},
  {path: 'products/:id', component: ProductDetailsComponent},
  {path: 'about', component: AboutComponent},
  {path: '', redirectTo: 'products', pathMatch: 'full'}, // default page
  {path: '**', component: PageNotFoundComponent} // 404 page, always last in the array
];

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ProductInputComponent,
    AboutComponent,
    PageNotFoundComponent,
    ProductDetailsComponent,
    ProductTagListComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    // other imports go here
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
