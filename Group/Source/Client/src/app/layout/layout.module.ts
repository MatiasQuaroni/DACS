import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { HeaderComponent } from './header/header.component';
import { TabBarComponent } from './tabs/tab-bar/tab-bar.component';
import { TabButtonComponent } from './tabs/tab-button/tab-button.component';
import { MainContentComponent } from './main-content/main-content.component';
import { TabsComponent } from './tabs/tabs-component/tabs.component';

@NgModule({
  declarations: [HeaderComponent, MainContentComponent],
  imports: [CommonModule, IonicModule],
  exports: [MainContentComponent, HeaderComponent],
})
export class LayoutModule {}
