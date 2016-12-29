
// DllLoaderDlg.cpp : implementation file
//

#include "stdafx.h"
#include "DllLoader.h"
#include "DllLoaderDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CDllLoaderDlg dialog



CDllLoaderDlg::CDllLoaderDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(IDD_DLLLOADER_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CDllLoaderDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_MFCEDITBROWSE_DLLPATH, m_mfcEditBrowseDllPath);
	DDX_Control(pDX, IDC_BTN_LOAD_DLL, m_btnLoadDll);
	DDX_Control(pDX, IDC_MFCEDITBROWSE_FILEPATH, m_mfcEditBrowseFileName);
}

BEGIN_MESSAGE_MAP(CDllLoaderDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BTN_LOAD_DLL, &CDllLoaderDlg::OnBnClickedBtnLoadDll)
	ON_EN_CHANGE(IDC_MFCEDITBROWSE_DLLPATH, &CDllLoaderDlg::OnEnChangeMfceditbrowseDllpath)
	ON_EN_CHANGE(IDC_MFCEDITBROWSE_FILEPATH, &CDllLoaderDlg::OnEnChangeMfceditbrowseFilepath)
END_MESSAGE_MAP()


// CDllLoaderDlg message handlers

BOOL CDllLoaderDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CDllLoaderDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CDllLoaderDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CDllLoaderDlg::OnBnClickedBtnLoadDll()
{
	// TODO: Add your control notification handler code here
	CString strPath("");
	m_mfcEditBrowseDllPath.GetWindowText(strPath);

	HANDLE hFind;
	WIN32_FIND_DATA data;
	CStringArray allFiles;
	CString strPathFilter("");
	CString strFileName("");

	if (strPath.IsEmpty())
	{
		m_mfcEditBrowseFileName.GetWindowText(strPath);
		allFiles.Add(strPath);
	}
	else
	{
		strPathFilter.Format(_T("%s\\*.dll"), strPath);
	}
	
	if (!strPathFilter.IsEmpty())
	{
		hFind = FindFirstFile(strPathFilter, &data);
		if (hFind != INVALID_HANDLE_VALUE) {
			do {
				strFileName.Format(_T("%s\\%s"), strPath, data.cFileName);
				allFiles.Add(strFileName);
			} while (FindNextFile(hFind, &data));
			FindClose(hFind);
		}
	}

	CString strError("");
	for (int i = 0; i < allFiles.GetCount(); i++)
	{
		strFileName = allFiles.GetAt(i);
		HINSTANCE handleDLL = LoadLibrary(strFileName);

		if (handleDLL == NULL)
		{
			strError.Format(_T("Failed to load '%s' library.\nLastError = %d"), strFileName, GetLastError());
			MessageBox(strError, _T("LoadLibrary Failed"));
		}
		else
		{
			FreeLibrary(handleDLL);
		}
	}
}



void CDllLoaderDlg::OnEnChangeMfceditbrowseDllpath()
{
	// TODO:  If this is a RICHEDIT control, the control will not
	// send this notification unless you override the CDialogEx::OnInitDialog()
	// function and call CRichEditCtrl().SetEventMask()
	// with the ENM_CHANGE flag ORed into the mask.

	// TODO:  Add your control notification handler code here
	CString strPath("");
	m_mfcEditBrowseDllPath.GetWindowText(strPath);
	m_btnLoadDll.EnableWindow(!strPath.IsEmpty());

	//m_mfcEditBrowseFileName.SetWindowText(_T(""));
}


void CDllLoaderDlg::OnEnChangeMfceditbrowseFilepath()
{
	// TODO:  If this is a RICHEDIT control, the control will not
	// send this notification unless you override the CDialogEx::OnInitDialog()
	// function and call CRichEditCtrl().SetEventMask()
	// with the ENM_CHANGE flag ORed into the mask.

	// TODO:  Add your control notification handler code here
	CString strPath("");
	m_mfcEditBrowseFileName.GetWindowText(strPath);
	m_btnLoadDll.EnableWindow(!strPath.IsEmpty());

	//m_mfcEditBrowseDllPath.SetWindowText(_T(""));
}
