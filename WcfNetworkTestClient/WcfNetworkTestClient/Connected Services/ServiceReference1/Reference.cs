﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfNetworkTestClient.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Cols", Namespace="http://schemas.datacontract.org/2004/07/WcfNetworkTestService")]
    [System.SerializableAttribute()]
    public partial class Cols : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreationTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TestNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreationTime {
            get {
                return this.CreationTimeField;
            }
            set {
                if ((this.CreationTimeField.Equals(value) != true)) {
                    this.CreationTimeField = value;
                    this.RaisePropertyChanged("CreationTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TestName {
            get {
                return this.TestNameField;
            }
            set {
                if ((object.ReferenceEquals(this.TestNameField, value) != true)) {
                    this.TestNameField = value;
                    this.RaisePropertyChanged("TestName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1", CallbackContract=typeof(WcfNetworkTestClient.ServiceReference1.IService1Callback))]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SearchCallback", ReplyAction="http://tempuri.org/IService1/SearchCallbackResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(string), Action="http://tempuri.org/IService1/SearchCallbackStringFault", Name="string", Namespace="http://schemas.microsoft.com/2003/10/Serialization/")]
        void SearchCallback();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SearchCallback", ReplyAction="http://tempuri.org/IService1/SearchCallbackResponse")]
        System.Threading.Tasks.Task SearchCallbackAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/StopSearch", ReplyAction="http://tempuri.org/IService1/StopSearchResponse")]
        void StopSearch();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/StopSearch", ReplyAction="http://tempuri.org/IService1/StopSearchResponse")]
        System.Threading.Tasks.Task StopSearchAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserLogIn", ReplyAction="http://tempuri.org/IService1/UserLogInResponse")]
        void UserLogIn(string userNickname, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserLogIn", ReplyAction="http://tempuri.org/IService1/UserLogInResponse")]
        System.Threading.Tasks.Task UserLogInAsync(string userNickname, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserSignUp", ReplyAction="http://tempuri.org/IService1/UserSignUpResponse")]
        bool UserSignUp(string userNickname, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserSignUp", ReplyAction="http://tempuri.org/IService1/UserSignUpResponse")]
        System.Threading.Tasks.Task<bool> UserSignUpAsync(string userNickname, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserLogOut", ReplyAction="http://tempuri.org/IService1/UserLogOutResponse")]
        void UserLogOut(string userNickname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserLogOut", ReplyAction="http://tempuri.org/IService1/UserLogOutResponse")]
        System.Threading.Tasks.Task UserLogOutAsync(string userNickname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUser", ReplyAction="http://tempuri.org/IService1/GetUserResponse")]
        bool GetUser(string userNickname, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUser", ReplyAction="http://tempuri.org/IService1/GetUserResponse")]
        System.Threading.Tasks.Task<bool> GetUserAsync(string userNickname, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAdmin", ReplyAction="http://tempuri.org/IService1/GetAdminResponse")]
        bool GetAdmin(string userNickname, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAdmin", ReplyAction="http://tempuri.org/IService1/GetAdminResponse")]
        System.Threading.Tasks.Task<bool> GetAdminAsync(string userNickname, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUsersOnline", ReplyAction="http://tempuri.org/IService1/GetUsersOnlineResponse")]
        string[] GetUsersOnline();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUsersOnline", ReplyAction="http://tempuri.org/IService1/GetUsersOnlineResponse")]
        System.Threading.Tasks.Task<string[]> GetUsersOnlineAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateAdminStatusTrue", ReplyAction="http://tempuri.org/IService1/UpdateAdminStatusTrueResponse")]
        void UpdateAdminStatusTrue(string userNickname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateAdminStatusTrue", ReplyAction="http://tempuri.org/IService1/UpdateAdminStatusTrueResponse")]
        System.Threading.Tasks.Task UpdateAdminStatusTrueAsync(string userNickname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateAdminStatusFalse", ReplyAction="http://tempuri.org/IService1/UpdateAdminStatusFalseResponse")]
        void UpdateAdminStatusFalse(string userNickname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateAdminStatusFalse", ReplyAction="http://tempuri.org/IService1/UpdateAdminStatusFalseResponse")]
        System.Threading.Tasks.Task UpdateAdminStatusFalseAsync(string userNickname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/TestIsPassed", ReplyAction="http://tempuri.org/IService1/TestIsPassedResponse")]
        void TestIsPassed(string userNickname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/TestIsPassed", ReplyAction="http://tempuri.org/IService1/TestIsPassedResponse")]
        System.Threading.Tasks.Task TestIsPassedAsync(string userNickname);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Callback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SendSearchResult", ReplyAction="http://tempuri.org/IService1/SendSearchResultResponse")]
        void SendSearchResult(WcfNetworkTestClient.ServiceReference1.Cols currentFoundResult);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WcfNetworkTestClient.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.DuplexClientBase<WcfNetworkTestClient.ServiceReference1.IService1>, WcfNetworkTestClient.ServiceReference1.IService1 {
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void SearchCallback() {
            base.Channel.SearchCallback();
        }
        
        public System.Threading.Tasks.Task SearchCallbackAsync() {
            return base.Channel.SearchCallbackAsync();
        }
        
        public void StopSearch() {
            base.Channel.StopSearch();
        }
        
        public System.Threading.Tasks.Task StopSearchAsync() {
            return base.Channel.StopSearchAsync();
        }
        
        public void UserLogIn(string userNickname, string password) {
            base.Channel.UserLogIn(userNickname, password);
        }
        
        public System.Threading.Tasks.Task UserLogInAsync(string userNickname, string password) {
            return base.Channel.UserLogInAsync(userNickname, password);
        }
        
        public bool UserSignUp(string userNickname, string password) {
            return base.Channel.UserSignUp(userNickname, password);
        }
        
        public System.Threading.Tasks.Task<bool> UserSignUpAsync(string userNickname, string password) {
            return base.Channel.UserSignUpAsync(userNickname, password);
        }
        
        public void UserLogOut(string userNickname) {
            base.Channel.UserLogOut(userNickname);
        }
        
        public System.Threading.Tasks.Task UserLogOutAsync(string userNickname) {
            return base.Channel.UserLogOutAsync(userNickname);
        }
        
        public bool GetUser(string userNickname, string password) {
            return base.Channel.GetUser(userNickname, password);
        }
        
        public System.Threading.Tasks.Task<bool> GetUserAsync(string userNickname, string password) {
            return base.Channel.GetUserAsync(userNickname, password);
        }
        
        public bool GetAdmin(string userNickname, string password) {
            return base.Channel.GetAdmin(userNickname, password);
        }
        
        public System.Threading.Tasks.Task<bool> GetAdminAsync(string userNickname, string password) {
            return base.Channel.GetAdminAsync(userNickname, password);
        }
        
        public string[] GetUsersOnline() {
            return base.Channel.GetUsersOnline();
        }
        
        public System.Threading.Tasks.Task<string[]> GetUsersOnlineAsync() {
            return base.Channel.GetUsersOnlineAsync();
        }
        
        public void UpdateAdminStatusTrue(string userNickname) {
            base.Channel.UpdateAdminStatusTrue(userNickname);
        }
        
        public System.Threading.Tasks.Task UpdateAdminStatusTrueAsync(string userNickname) {
            return base.Channel.UpdateAdminStatusTrueAsync(userNickname);
        }
        
        public void UpdateAdminStatusFalse(string userNickname) {
            base.Channel.UpdateAdminStatusFalse(userNickname);
        }
        
        public System.Threading.Tasks.Task UpdateAdminStatusFalseAsync(string userNickname) {
            return base.Channel.UpdateAdminStatusFalseAsync(userNickname);
        }
        
        public void TestIsPassed(string userNickname) {
            base.Channel.TestIsPassed(userNickname);
        }
        
        public System.Threading.Tasks.Task TestIsPassedAsync(string userNickname) {
            return base.Channel.TestIsPassedAsync(userNickname);
        }
    }
}
