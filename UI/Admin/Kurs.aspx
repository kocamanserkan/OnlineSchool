<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Kurs.aspx.cs" Inherits="UI.Admin.Kurs" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script type="text/javascript">



        function openModal() {
            //alert('asdfa');
            $('#bd-example-modal-lg').modal('show');

        }
    
</script>

    <meta charset="utf-8">


    <div class="header">

        <div class="header-right">


            <div class="user-info-dropdown">
                <div class="dropdown">
                    <a class="dropdown-toggle" href="#" role="button" data-toggle="dropdown">
                        <span class="user-icon">
                            <img src="vendors/images/photo1.jpg" alt="">
                        </span>

                        <asp:Label CssClass="user-name" ID="txtFullAd" runat="server" Text=""></asp:Label>
                        <%--<span class="user-name">Serkan Kocaman</span>--%>
                    </a>
                    <div class="dropdown-menu dropdown-menu-right dropdown-menu-icon-list">
                        <a class="dropdown-item" href="Profil.aspx"><i class="dw dw-user1"></i>Profilim</a>
                        <a class="dropdown-item" href="Profil.aspx"><i class="dw dw-settings2"></i>Profil Ayarları</a>

                        <a class="dropdown-item" href="login.aspx"><i class="dw dw-logout"></i>Çıkış</a>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <div class="left-side-bar">

        <div class="menu-block customscroll">
            <div class="sidebar-menu">
                <ul id="accordion-menu">
                    <li class="dropdown">
                        <a href="javascript:;" class="dropdown-toggle">
                            <span class="micon dw dw-house-1"></span><span class="mtext">Uygunsuzluk Modülü</span>
                        </a>
                        <ul class="submenu">
                            <li><a href="Home.aspx">Ana Sayfa</a></li>
                            <li><a href="Kurs.aspx">Kurslar</a></li>
                            <li><a href="Trainer.aspx">Öğretmenler</a></li>
                            <li><a href="Student.aspx">Öğrenciler</a></li>
                            <li><a href="Material.aspx">Kurs Materyalleri</a></li>
                            <li><a href="Approval.aspx">Onay İşlemleri</a></li>


                        </ul>

                    </li>


                </ul>
            </div>
        </div>
    </div>
    <div class="mobile-menu-overlay"></div>

    <div class="pd-ltr-20 xs-pd-20-10" style="margin-left: 10%; width: 1230px;">

        <div class="min-height-200px">

            <!-- Simple Datatable start -->
            <div class="card-box mb-190">
                <div class="pd-20" style="margin-top: 100px">
                    <h4 style="text-align:center;">  Kurs Listesi  </h4>
                    <button class="btn btn-primary btn-sm scroll-click" data-toggle="modal" style="margin-left: 963px;" data-target="#bd-example-modal-lg" type="button">Kurs Edit +/- </button>
                    <div class="modal fade bs-example-modal-lg" id="bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                        <div class="modal-dialog modal-lg modal-dialog-centered">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title" id="myLargeModalLabel">Kurs Edit Ekranı (Yeni Kurs Eklemek için Ekranı Temizleye Tıklayın)</h4>
                                    <asp:Button ID="btnEkranTemizle" class="btn btn-primary btn-sm scroll-click" runat="server" Onclick="btnEkranTemizle_Click" Text="Ekranı Temizle" />
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                </div>
                                <div class="modal-body">

                                    <div class="pd-ltr-20">
                                        <div class="card-box pd-20 height-100-p mb-30">
                                            <%--  <div class="row align-items-center">--%>
                                            <form>

                                                <h4 class="text-blue h5 mb-20">Kurs Ekleyin</h4>
                                                <div class="form-group">
                                                    <label>Kurs Başlığı</label>

                                                    <asp:TextBox ID="txtKursTitle" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                                </div>

                                                <div class="form-group">
                                                    <label>Kurs Tarihi</label>
                                                    <asp:TextBox ID="dtpKursDate" TextMode="Date" class="datepickers form-control form-control-lg" runat="server"></asp:TextBox>
                                                    <%--  <input id="txt_tckn" class="form-control form-control-lg" type="text">--%>
                                                </div>


                                                <div class="form-group">
                                                    <label>Kurs Süresi (Saat)</label>
                                                    <asp:TextBox ID="txtKursSure" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>Kurs İçeriği</label>
                                                    <asp:TextBox ID="txtKursTopic" TextMode="MultiLine" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                                    <%--       <input id="txtSicil" class="form-control form-control-lg" type="text">--%>
                                                </div>
                                            </form>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Kapat X</button>
                                            <asp:Button ID="btnKursEkle" OnClick="btnKursEkle_Click" class="btn btn-primary" runat="server" Text="Kurs Ekle + " />
                                            <asp:Button ID="btnKursUpdate" OnClick="btnKursUpdate_Click" class="btn btn-primary" runat="server" Text="Güncelle {} " />
                                            <asp:Button ID="btnKursDelete" OnClick="btnKursDelete_Click" BackColor="#ff3300" class="btn btn-primary" runat="server" Text="Kurs Sil - " />
                                        </div>
                                    </div>
                                </div>
                            </div>



                        </div>

                        <%--GridView--%>
                    </div>
                </div>
            </div>

            <div style="width: 100%; height: 400px; overflow: scroll">
                <asp:GridView ID="grdKurs" CssClass="data-table table stripe hover nowrap" AutoGenerateSelectButton="True" DataKeyNames="KursId" AutoGenerateColumns="true" GridLines="None" runat="server" OnSelectedIndexChanged="grdKurs_SelectedIndexChanged">
                    <SelectedRowStyle BackColor="#FF6666" />
                </asp:GridView>

            </div>
            <div>
                <h4 style="text-align:center;" >Öğretmenler</h4>
                <asp:CheckBoxList CssClass="form-control form-control-lg" Height="100 px" ID="cblTrainers" runat="server"></asp:CheckBoxList>
                <asp:Button ID="btnTrainerAta"  class="btn btn-primary" OnClick="btnTrainerAta_Click" runat="server" Text=" Kursa Öğretmen Ata" style="margin-top: -108px;  margin-left: 950px;" />
            </div>

            <div class="pd-ltr-20">

                <div id="bura" class="card-box pd-20 height-100-p mb-30" style="margin-top: -525px; z-index: 3; z-index: 3; position: relative; display: none;">
                    <%--  <div class="row align-items-center">--%>
                    <form>

                        <h4 class="text-blue h5 mb-20">Kurs Ekleyin</h4>
                        <div class="form-group">
                            <label>Kurs Başlığı</label>

                            <asp:TextBox ID="TextBox1" class="form-control form-control-lg" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Kurs Tarihi</label>
                            <asp:TextBox ID="TextBox2" TextMode="Date" class="datepickers form-control form-control-lg" runat="server"></asp:TextBox>
                            <%--  <input id="txt_tckn" class="form-control form-control-lg" type="text">--%>
                        </div>


                        <div class="form-group">
                            <label>Kurs Süresi (Saat)</label>
                            <asp:TextBox ID="TextBox3" class="form-control form-control-lg" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Kurs İçeriği</label>
                            <asp:TextBox ID="TextBox4" TextMode="MultiLine" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            <%--       <input id="txtSicil" class="form-control form-control-lg" type="text">--%>
                        </div>
                        <div class="form-group">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Kapat</button>
                            <asp:Button ID="Button1" OnClick="btnKursEkle_Click" class="btn btn-primary" runat="server" Text="Kurs Ekle + " />
                        </div>
                    </form>

                    <div class="modal-footer">
                    </div>

                </div>
            </div>

        </div>
    </div>



    

</asp:Content>


