using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using StatefulModel;

namespace Dabuttemasu.Models
{
    public class TreeViewItemEntity<T> : BindableBase
    {
        /// <summary>見出し を取得、設定</summary>
        private string viewName_;
        /// <summary>見出し を取得、設定</summary>
        public string ViewName
        {
            get => this.viewName_;

            set => this.SetProperty(ref this.viewName_, value);
        }

        /// <summary>リストボックスの値 を取得、設定</summary>
        private T listBoxValue_;
        /// <summary>リストボックスの値 を取得、設定</summary>
        public T ListBoxValue
        {
            get => this.listBoxValue_;

            set => this.SetProperty(ref this.listBoxValue_, value);
        }

        /// <summary>リストボックスの子ノード を取得、設定</summary>
        private ObservableSynchronizedCollection<TreeViewItemEntity<T>> child_;
        /// <summary>リストボックスの子ノード を取得、設定</summary>
        public ObservableSynchronizedCollection<TreeViewItemEntity<T>> Child
        {
            get => this.child_;

            set => this.SetProperty(ref this.child_, value);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.ViewName)) {
                return this.ListBoxValue.ToString();
            }
            return this.ViewName;
        }

        public TreeViewItemEntity(string viewName, T value, IEnumerable<TreeViewItemEntity<T>> child = null)
        {
            this.viewName_ = viewName;
            this.listBoxValue_ = value;
            if (child == null) {
                return;
            }
            this.child_ = new ObservableSynchronizedCollection<TreeViewItemEntity<T>>();
            foreach (var item in child) {
                this.child_.Add(item);
            }
            
        }
    }
}
